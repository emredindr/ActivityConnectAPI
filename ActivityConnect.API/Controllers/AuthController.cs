using ActivityConnect.Business.Abstract;
using ActivityConnect.Core.ViewModels.UserVM;
using Microsoft.AspNetCore.Mvc;

namespace ActivityConnect.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : BaseController
{

    private readonly IUserAppService _userAppService;
    public AuthController(IUserAppService userAppService)
    {
        _userAppService = userAppService;
    }

    [HttpPost("Login")]
    public async Task<UserLoginOutput> Login(UserLoginInput input)
    {
        return await _userAppService.Login(input);
    }

    [HttpPost("Register")]
    public async Task<UserLoginOutput> Register(UserRegisterInput input)
    {
        var userInfo = await _userAppService.Register(input);
        return userInfo;
    }
}
