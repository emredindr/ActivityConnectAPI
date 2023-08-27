using ActivityConnect.Core.Dto.Request;
using ActivityConnect.Entities.Enums;

namespace ActivityConnect.Entities.ViewModels.UserVM
{
    public class GetAllUserInput : ListResultReguest
    {
        public string SearchText { get; set; }
        public UserStatusEnum IsActive { get; set; }
    }
}
