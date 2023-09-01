using ActivityConnect.Core.Dto.Response;
using ActivityConnect.Core.ViewModels.ActivityTypeVM;
using ActivityConnect.Core.ViewModels.ActivityVM;

namespace ActivityConnect.Business.Abstract;

public interface IActivityTypeAppService
{
    Task<ListResult<GetAllActivityTypeInfo>> GetActivityTypeList();
}
