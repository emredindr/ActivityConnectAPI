using ActivityConnect.Core.DbModels;
using ActivityConnect.Core.Dto.Response;
using ActivityConnect.Core.ViewModels.UserPermissionVM;

namespace ActivityConnect.Business.Abstract
{
    public interface IUserPermissionAppService
    {
        Task<ListResult<PermissionAndUserInfo>> GetUserPermissionList(int userId);
        Task<List<Permission>> GetUserPermissions(int userId);

        Task CreateOrUpdateUserPermission(CreateOrUpdateUserPermissionInput input);
    }
}
