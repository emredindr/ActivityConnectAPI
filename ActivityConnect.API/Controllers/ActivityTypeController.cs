using ActivityConnect.Business.Abstract;
using ActivityConnect.Core.Dto.Response;
using ActivityConnect.Core.ViewModels.ActivityTypeVM;
using Microsoft.AspNetCore.Mvc;

namespace ActivityConnect.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityTypeController : BaseController
    {
        private readonly IActivityTypeAppService _activityTypeAppService;

        public ActivityTypeController(IActivityTypeAppService activityTypeAppService)
        {
            _activityTypeAppService = activityTypeAppService;
        }

        [HttpGet("GetActivityTypeList")]
        public async Task<ListResult<GetAllActivityTypeInfo>> GetActivityTypeList()
        {
            return await _activityTypeAppService.GetActivityTypeList();
        }
    }
}
