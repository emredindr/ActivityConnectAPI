using ActivityConnect.Core.Dto.Response;
using ActivityConnect.Core.ViewModels.ActivityVM;

namespace ActivityConnect.Business.Abstract;

public interface IActivityAppService
{
    Task<ListResult<GetAllActivityInfo>> GetActivityList();
    Task<GetAllVenueActivityInfo> GetActivityListByVenueId(int venueId);
    Task CreateActivity(CreateActivityInput input);
}
