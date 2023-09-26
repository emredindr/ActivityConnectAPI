using ActivityConnect.Core.Dto.Response;
using ActivityConnect.Core.ViewModels.ActivityVM;

namespace ActivityConnect.Business.Abstract;

public interface IActivityAppService
{
    Task<ListResult<GetAllActivityInfo>> GetActivityList(GetAllActivityInput input);
    Task<GetAllVenueActivityInfo> GetActivityListByVenueId(int venueId);
    Task CreateActivity(CreateActivityInput input);
}
