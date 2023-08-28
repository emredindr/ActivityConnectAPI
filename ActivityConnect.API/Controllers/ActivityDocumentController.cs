using ActivityConnect.Business.Abstract;
using ActivityConnect.Core.ViewModels.ActivityDocumentVM;
using Microsoft.AspNetCore.Mvc;

namespace ActivityConnect.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityDocumentController : BaseController
    {
        private readonly IActivityDocumentAppService _activityDocumentAppService;

        public ActivityDocumentController(IActivityDocumentAppService activityDocumentAppService)
        {
            _activityDocumentAppService = activityDocumentAppService;
        }

        [HttpPost("CreateActivityDocument")]
        public async Task CreateActivityDocument(CreateActivityDocumentInput input)
        {
            await _activityDocumentAppService.CreateActivityDocument(input);
        }
    }
}
