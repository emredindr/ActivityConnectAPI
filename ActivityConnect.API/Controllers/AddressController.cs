using ActivityConnect.Business.Abstract;
using ActivityConnect.Core.ViewModels.AddressVM;
using Microsoft.AspNetCore.Mvc;

namespace ActivityConnect.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AddressController : BaseController
{

    private readonly IAddressAppService _addressAppService;

    public AddressController(IAddressAppService addressAppService)
    {
        _addressAppService = addressAppService;
    }
    
    [HttpPost("CreateAddress")]
    public async Task CreateAddress(CreateAddressInput input)
    {
        await _addressAppService.CreateAddress(input);
    }

}
