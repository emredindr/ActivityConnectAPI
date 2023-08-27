using ActivityConnect.Core.Dto.Request;

namespace ActivityConnect.Entities.ViewModels.UserDocumentVM
{
    public class GetAllUserDocumentInput : ListResultReguest
    {
        public string SearchText { get; set; }
        public int? CategoryId { get; set; }
        public int? UserId { get; set; }

    }
}
