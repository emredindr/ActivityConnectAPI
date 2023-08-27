using ActivityConnect.Core.Dto.Request;

namespace ActivityConnect.Entities.ViewModels.PermissionVM
{
    public class GetAllPermissionInput : ListResultReguest
    {
        public string SearchText { get; set; }
    }
}
