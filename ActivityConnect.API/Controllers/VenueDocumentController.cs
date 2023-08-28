using ActivityConnect.Business.Abstract;
using ActivityConnect.Core.ViewModels.VenueDocumentVM;
using Microsoft.AspNetCore.Mvc;

namespace ActivityConnect.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VenueDocumentController : BaseController
    {
        private readonly IVenueDocumentAppService _venueDocumentAppService;

        public VenueDocumentController(IVenueDocumentAppService venueDocumentAppService)
        {
            _venueDocumentAppService = venueDocumentAppService;
        }

        [HttpPost("CreateVenueDocument")]
        public async Task CreateVenueDocument(CreateVenueDocumentInput input)
        {
            await _venueDocumentAppService.CreateVenueDocument(input);
        }
    }
}
