using ActivityConnect.Core.ViewModels.VenueDocument;

namespace ActivityConnect.Business.Abstract;

public interface IVenueDocumentAppService
{
    Task CreateVenueDocument(CreateVenueDocumentInput input);
}
