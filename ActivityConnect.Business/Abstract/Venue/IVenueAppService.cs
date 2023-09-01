using ActivityConnect.Core.Dto.Response;
using ActivityConnect.Core.ViewModels.VenueVM;
using ActivityConnect.Core.ViewModels.VenueVM.Dtos;

namespace ActivityConnect.Business.Abstract;

public interface IVenueAppService
{
    Task<ListResult<GetAllVenueInfo>> GetVenueList();
    Task<ListResult<VenueDto>> GetVenueListByCityId(int cityId);
    Task CreateVenue(CreateVenueInput input);
}
