using ActivityConnect.Business.Abstract;
using ActivityConnect.Core.Dto.Response;
using ActivityConnect.Core.ViewModels.UserVM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ActivityConnect.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : BaseController
{

    private readonly IUserAppService _userAppService;
    public UserController(IUserAppService userAppService)
    {
        _userAppService = userAppService;
    }

    [HttpGet("GetUserById")]
    public async Task<GetAllUserInfo> GetUserById(int userId)
    {
        return await _userAppService.GetUserById(userId);
    }

    [HttpGet("GetCurrentUserInfo")]
    public async Task<GetAllUserInfo> GetCurrentUserInfo()
    {
        return await _userAppService.GetCurrentUserInfo();
    }

    [HttpGet("GetUserList")]
    public async Task<ListResult<GetAllUserInfo>> GetUserList([FromQuery] GetAllUserInput input)
    {
        return await _userAppService.GetUserList(input);
    }

    [HttpGet("GetAllUsersByPage")]
    public async Task<PagedResult<GetAllUserInfo>> GetAllUsersByPage([FromQuery] GetAllUserInput getAllUserInput)
    {
        return await _userAppService.GetAllUsersByPage(getAllUserInput);
    }

    [HttpPost("CreateUser")]
    public async Task CreateUser(CreateUserInput createUserInput)
    {
        await _userAppService.CreateUser(createUserInput);
    }

    [HttpPost("UpdateUser")]
    public async Task UpdateUser(UpdateUserInput updateUserInput)
    {
        await _userAppService.UpdateUser(updateUserInput);
    }

    [HttpPost("UpdateCurrentUserInfo")]
    public async Task UpdateCurrentUserInfo(UpdateUserInput updateUserInput)
    {
        await _userAppService.UpdateCurrentUserInfo(updateUserInput);
    }

    [HttpDelete("DeleteUser")]
    public async Task DeleteUser(int userId)
    {
        await _userAppService.DeleteUser(userId);
    }
}
