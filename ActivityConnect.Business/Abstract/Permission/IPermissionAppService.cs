using ActivityConnect.Core.Dto.Response;
using ActivityConnect.Core.ViewModels.PermissionVM;

namespace ActivityConnect.Business.Abstract
{
    public interface IPermissionAppService
    {
        Task<ListResult<GetAllPermissionInfo>> GetPermissionList();
        Task<GetAllPermissionInfo> GetPermissionById(int permissionId);

        Task CreatePermission(CreatePermissionInput input);
        Task UpdatePermission(UpdatePermissionInput input);
        Task DeletePermission(int permissionId);
    }
}
