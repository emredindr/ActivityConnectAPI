using ActivityConnect.Business.Abstract;
using ActivityConnect.Business.ValidationRules.FluentValidation.Permission;
using ActivityConnect.Core.Aspects.AutoFac.Authorize;
using ActivityConnect.Core.Aspects.AutoFac.Validation;
using ActivityConnect.Core.Authorization;
using ActivityConnect.Core.DbModels;
using ActivityConnect.Core.Dto.Response;
using ActivityConnect.Core.Extensions.ResponseAndExceptionMiddleware;
using ActivityConnect.Core.Repositories;
using ActivityConnect.Core.ViewModels.PermissionVM;
using Microsoft.EntityFrameworkCore;

namespace ActivityConnect.Business.Concreate
{
    public class PermissionAppService : BaseAppService, IPermissionAppService
    {
        private readonly IRepository<Permission, int> _permissionRepository;
        public PermissionAppService
            (
            IRepository<Permission, int> permissionRepository
            )
        {
            _permissionRepository = permissionRepository;
        }

        //[AuthorizeAspect(new string[] { AllPermissions.Permission_List })]
        public async Task<ListResult<GetAllPermissionInfo>> GetPermissionList()
        {
            //var query =await _permissionRepository.GetAll().Where(x=>!x.IsDeleted).ToListAsync();
            var query = from permission in _permissionRepository.GetAll()
                        where !permission.IsDeleted
                        select new GetAllPermissionInfo
                        {
                            Id = permission.Id,
                            Name = permission.Name,
                            Description = permission.Description
                        };

            var permissions = await query.ToListAsync();
            var mappedPermissions = Mapper.Map<List<GetAllPermissionInfo>>(permissions);

            return new ListResult<GetAllPermissionInfo>(mappedPermissions);
        }

        public async Task<GetAllPermissionInfo> GetPermissionById(int permissionId)
        {
            var permission = await _permissionRepository.FirstOrDefaultAsync(x => x.Id == permissionId && !x.IsDeleted);
            if (permission == null)
            {
                throw new ApiException($"{permissionId} nolu Id degeri bulunamadı");
            }
            var mappedPermission = Mapper.Map<GetAllPermissionInfo>(permission);
            return mappedPermission;
        }

        [AuthorizeAspect(new string[] { AllPermissions.Permission_Create })]
        [ValidationAspect(typeof(CreatePermissionInputValidator))]
        public async Task CreatePermission(CreatePermissionInput input)
        {
            var permissionName = await _permissionRepository.FirstOrDefaultAsync(x => x.Name == input.Name && x.IsDeleted == false);
            if (permissionName != null)
            {
                throw new ApiException("hata kayıtlı oge zaten var");
            }

            var newPermission = Mapper.Map<Permission>(input);
            await _permissionRepository.InsertAsync(newPermission);
        }

        [AuthorizeAspect(new string[] { AllPermissions.Permission_Update })]
        [ValidationAspect(typeof(UpdatePermissionInputValidator))]
        public async Task UpdatePermission(UpdatePermissionInput input)
        {

            var checkPermission = await _permissionRepository.GetAsync(input.Id);
            if (checkPermission == null)
            {
                throw new ApiException($"{input.Id} nolu Id degeri bulunamadı");
            }

            var permission = await _permissionRepository.FirstOrDefaultAsync(x => x.Name == input.Name && x.IsDeleted == false);
            if (permission != null)
            {
                if (permission.Id != checkPermission.Id)
                {
                    throw new ApiException("Aynı isimle aktif permission oldugu icin guncellenemedi. ");
                }
            }
            Mapper.Map(input, checkPermission);
            await _permissionRepository.UpdateAsync(checkPermission);
        }

        [AuthorizeAspect(new string[] { AllPermissions.Permission_Delete })]
        public async Task DeletePermission(int permissionId)
        {
            var checkPermission = await _permissionRepository.GetAsync(permissionId);
            if (checkPermission == null)
            {
                throw new ApiException($"{permissionId} nolu Id degeri bulunamadı");
            }
            await _permissionRepository.DeleteAsync(permissionId);


        }
    }
}
