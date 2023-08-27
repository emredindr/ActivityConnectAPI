using ActivityConnect.Core.Dto.Request;

namespace ActivityConnect.Entities.ViewModels.CategoryVM
{
    public class GetAllCategoryInput : ListResultReguest
    {

        public string SearchText { get; set; }
    }
}
