using ActivityConnect.Business.Abstract;
using ActivityConnect.Core.Dto.Response;
using ActivityConnect.Core.ViewModels.ActivityVM;
using Microsoft.AspNetCore.Mvc;

namespace ActivityConnect.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : BaseController
    {
        private readonly IActivityAppService _activityAppService;

        public ActivityController(IActivityAppService activityAppService)
        {
            _activityAppService = activityAppService;
        }

        [HttpGet("GetActivityList")]
        public async Task<ListResult<GetAllActivityInfo>> GetActivityList([FromQuery] GetAllActivityInput input)
        {
            return await _activityAppService.GetActivityList(input);
        }

        [HttpGet("GetActivityListByVenueId")]
        public async Task<GetAllVenueActivityInfo> GetActivityListByVenueId(int venueId)
        {
            return await _activityAppService.GetActivityListByVenueId(venueId);
        }

        [HttpPost("CreateActivity")]
        public async Task CreateActivity(CreateActivityInput input)
        {
            await _activityAppService.CreateActivity(input);
        }
    }
}
