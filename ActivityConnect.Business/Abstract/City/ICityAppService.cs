using ActivityConnect.Core.Dto.Response;
using ActivityConnect.Core.ViewModels.CityVM;

namespace ActivityConnect.Business.Abstract;

public interface ICityAppService
{
    Task<ListResult<GetAllCityInfo>> GetCityList();
}
