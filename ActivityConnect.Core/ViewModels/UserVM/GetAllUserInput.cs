using ActivityConnect.Core.Dto.Request;
using ActivityConnect.Core.Enums;

namespace ActivityConnect.Core.ViewModels.UserVM
{
    public class GetAllUserInput : ListResultReguest
    {
        public string SearchText { get; set; }
        public UserStatusEnum IsActive { get; set; }
    }
}
