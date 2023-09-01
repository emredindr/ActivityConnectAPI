using ActivityConnect.Business.Abstract;
using ActivityConnect.Core.Dto.Response;
using ActivityConnect.Core.ViewModels.CityVM;
using Microsoft.AspNetCore.Mvc;

namespace ActivityConnect.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : BaseController
    {
        private readonly ICityAppService _cityAppService;

        public CityController(ICityAppService cityAppService)
        {
            _cityAppService = cityAppService;
        }

        [HttpGet("GetCityList")]
        public async Task<ListResult<GetAllCityInfo>> GetCityList()
        {
            return await _cityAppService.GetCityList();
        }
    }
}
