using ActivityConnect.Core.Dto.Request;

namespace ActivityConnect.Entities.ViewModels.CategoryTypeVM
{
    public class GetAllCategoryTypeInput : ListResultReguest
    {
        public string SearchText { get; set; }

    }
}
