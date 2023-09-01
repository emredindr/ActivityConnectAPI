using ActivityConnect.Business.Abstract;
using ActivityConnect.Core.DbModels;
using ActivityConnect.Core.Dto.Response;
using ActivityConnect.Core.Repositories;
using ActivityConnect.Core.ViewModels.CityVM;
using Microsoft.EntityFrameworkCore;

namespace ActivityConnect.Business.Concreate;

public class CityAppService : BaseAppService, ICityAppService
{
    private readonly IRepository<City, int> _cityRepository;

    public CityAppService(IRepository<City, int> cityRepository)
    {
        _cityRepository = cityRepository;
    }

    public async Task<ListResult<GetAllCityInfo>> GetCityList()
    {
        var cities = await _cityRepository.GetAll().ToListAsync();

        var mappedCities = Mapper.Map<List<GetAllCityInfo>>(cities);

        return new ListResult<GetAllCityInfo>(mappedCities);
    }
}
