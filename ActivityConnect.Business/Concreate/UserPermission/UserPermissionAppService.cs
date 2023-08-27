using ActivityConnect.Business.Abstract;
using ActivityConnect.Core.Aspects.AutoFac.Authorize;
using ActivityConnect.Core.Authorization;
using ActivityConnect.Core.DbModels;
using ActivityConnect.Core.Dto.Response;
using ActivityConnect.Core.Extensions.ResponseAndExceptionMiddleware;
using ActivityConnect.Core.Repositories;
using ActivityConnect.Core.ViewModels.UserPermissionVM;
using Microsoft.EntityFrameworkCore;

namespace ActivityConnect.Business.Concreate
{
    public class UserPermissionAppService : IUserPermissionAppService
    {
        private readonly IRepository<Permission, int> _permissionRepository;
        private readonly IRepository<UserPermission, int> _userPermissionRepository;
        private readonly IRepository<User, int> _userRepository;

        public UserPermissionAppService
            (
            IRepository<UserPermission, int> userPermissionRepository,
            IRepository<Permission, int> permissionRepository,
            IRepository<User, int> userRepository
            )
        {
            _permissionRepository = permissionRepository;
            _userPermissionRepository = userPermissionRepository;
            _userRepository = userRepository;
        }

        [AuthorizeAspect(new string[] { AllPermissions.UserPermission_CreateOrUpdate })]
        public async Task CreateOrUpdateUserPermission(CreateOrUpdateUserPermissionInput input)
        {
            var checkUser = await _userRepository.FirstOrDefaultAsync(x => !x.IsDeleted && x.Id == input.UserId);
            if (checkUser == null)
            {
                throw new ApiException("user bulunamadı ");
            }

            var userPermissionList = _userPermissionRepository.GetAllList(x => x.UserId == input.UserId);
            var userPermissionIdList = userPermissionList.Select(x => x.PermissionId).ToList();

            var selectedPermissionIdList = input.PermissionList.Select(x => x.PermissionId).ToList();

            //Silinecek Kayıtlar
            var differanceFromSelected = userPermissionIdList.Except(selectedPermissionIdList).ToList();

            //Eklenecek kayıtlar
            var differanceFromNotSelected = selectedPermissionIdList.Except(userPermissionIdList).ToList();

            foreach (var addItemId in differanceFromNotSelected)
            {
                await _userPermissionRepository.InsertAsync(new UserPermission
                {
                    UserId = input.UserId,
                    PermissionId = addItemId,
                });
            }
            foreach (var deleteItemId in differanceFromSelected)
            {

                var query = _userPermissionRepository.FirstOrDefault(x => x.PermissionId == deleteItemId && x.UserId == input.UserId);
                await _userPermissionRepository.RemoveAsync(query.Id);
            }
        }

        public async Task<ListResult<PermissionAndUserInfo>> GetUserPermissionList(int userId)
        {
            var checkUser = _userRepository.FirstOrDefault(x => !x.IsDeleted && x.Id == userId);
            if (checkUser == null)
            {
                throw new ApiException("user bulunamadı ");
            }

            var result = new List<PermissionAndUserInfo>();
            var userPermissionList = await _userPermissionRepository.GetAll().Where(x => x.UserId == userId).OrderBy(x => x.PermissionId).ThenBy(x => x.PermissionId).ToListAsync();

            var permissionList = await _permissionRepository.GetAll().Where(x => !x.IsDeleted).OrderBy(x => x.Id).ThenBy(x => x.Id).ToListAsync();

            foreach (var childItem in permissionList)
            {
                var userPermissionCheck = userPermissionList.Any(x => x.PermissionId == childItem.Id);
                result.Add(new PermissionAndUserInfo
                {
                    PermissionId = childItem.Id,
                    PermissionName = childItem.Name,
                    IsChecked = userPermissionCheck,
                });
            }

            return new ListResult<PermissionAndUserInfo>(result);
        }

        public async Task<List<Permission>> GetUserPermissions(int userId)
        {
            var result = from permission in _permissionRepository.GetAll()
                         join userPermission in _userPermissionRepository.GetAll() on permission.Id equals userPermission.PermissionId
                         where userPermission.UserId == userId
                         select permission;
            return await result.ToListAsync();
        }
    }




}
