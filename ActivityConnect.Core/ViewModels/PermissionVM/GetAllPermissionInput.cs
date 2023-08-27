using ActivityConnect.Core.Dto.Request;

namespace ActivityConnect.Core.ViewModels.PermissionVM
{
    public class GetAllPermissionInput : ListResultReguest
    {
        public string SearchText { get; set; }
    }
}
