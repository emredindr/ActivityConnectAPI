using ActivityConnect.Business.Abstract;
using ActivityConnect.Core.Dto.Response;
using ActivityConnect.Core.ViewModels.UserPermissionVM;
using Microsoft.AspNetCore.Mvc;

namespace ActivityConnect.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UserPermissionController : ControllerBase
    {
        private readonly IUserPermissionAppService _userPermissionAppService;
        public UserPermissionController(IUserPermissionAppService userPermissionAppService)
        {
            _userPermissionAppService = userPermissionAppService;
        }

        [HttpGet("GetUserPermissionList")]
        public async Task<ListResult<PermissionAndUserInfo>> GetUserPermissionList(int userId)
        {
            return await _userPermissionAppService.GetUserPermissionList(userId);
        }

        [HttpPost("CreateOrUpdateUserPermission")]
        public async Task CreateOrUpdateUserPermission(CreateOrUpdateUserPermissionInput input)
        {
            await _userPermissionAppService.CreateOrUpdateUserPermission(input);
        }
    }
}
