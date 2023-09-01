using ActivityConnect.Business.Abstract;
using ActivityConnect.Core.Dto.Response;
using ActivityConnect.Core.ViewModels.VenueVM;
using ActivityConnect.Core.ViewModels.VenueVM.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace ActivityConnect.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VenueController : BaseController
{

    private readonly IVenueAppService _venueAppService;

    public VenueController(IVenueAppService venueAppService)
    {
        _venueAppService = venueAppService;
    }

    [HttpGet("GetVenueList")]
    public async Task<ListResult<GetAllVenueInfo>> GetVenueList()
    {
        return await _venueAppService.GetVenueList();
    }

    [HttpGet("GetVenueListByCityId")]
    public async Task<ListResult<VenueDto>> GetVenueListByCityId(int cityId)
    {
        return await _venueAppService.GetVenueListByCityId(cityId);
    }

    [HttpPost("CreateVenue")]
    public async Task CreateVenue(CreateVenueInput input)
    {
        await _venueAppService.CreateVenue(input);
    }

}
