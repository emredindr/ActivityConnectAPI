using ActivityConnect.Core.ViewModels.VenueDocumentVM;

namespace ActivityConnect.Business.Abstract;

public interface IVenueDocumentAppService
{
    Task CreateVenueDocument(CreateVenueDocumentInput input);
}
