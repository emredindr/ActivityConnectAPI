using ActivityConnect.Core.Dto.Request;

namespace ActivityConnect.Entities.ViewModels.PermissionGroupVM
{
    public class GetAllPermissionGroupInput : ListResultReguest
    {
        public string SearchText { get; set; }
    }
}
