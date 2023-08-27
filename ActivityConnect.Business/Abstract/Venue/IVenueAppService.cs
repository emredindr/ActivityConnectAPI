using ActivityConnect.Core.Dto.Response;
using ActivityConnect.Core.ViewModels.VenueVM;

namespace ActivityConnect.Business.Abstract;

public interface IVenueAppService
{
    Task<ListResult<GetAllVenueInfo>> GetVenueList();
    Task CreateVenue(CreateVenueInput input);
}
