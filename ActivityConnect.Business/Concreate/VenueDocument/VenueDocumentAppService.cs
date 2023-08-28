using ActivityConnect.Business.Abstract;
using ActivityConnect.Business.ValidationRules.FluentValidation.VenueDocument;
using ActivityConnect.Core.Aspects.AutoFac.Validation;
using ActivityConnect.Core.DbModels;
using ActivityConnect.Core.Extensions.ResponseAndExceptionMiddleware;
using ActivityConnect.Core.Repositories;
using ActivityConnect.Core.ViewModels.VenueDocumentVM;

namespace ActivityConnect.Business.Concreate;

public class VenueDocumentAppService : BaseAppService,IVenueDocumentAppService
{
    private readonly IRepository<VenueDocument, int> _venueDocumentRepository;
    private readonly IRepository<Document, int> _documentRepository;
    private readonly IRepository<Venue, int> _venueRepository;

    public VenueDocumentAppService(IRepository<VenueDocument, int> venueDocumentRepository, IRepository<Venue, int> venueRepository, IRepository<Document, int> documentRepository)
    {
        _venueDocumentRepository = venueDocumentRepository;
        _venueRepository = venueRepository;
        _documentRepository = documentRepository;
    }

    [ValidationAspect(typeof(CreateVenueDocumentInputValidator))]
    public async Task CreateVenueDocument(CreateVenueDocumentInput input)
    {
        var venue = await _venueRepository.FirstOrDefaultAsync(x => x.Id == input.VenueId);
        if (venue == null) throw new ApiException($"{venue.Id} nolu Id degeri bulunamadı");

        var document = await _documentRepository.FirstOrDefaultAsync(x => x.Id == input.DocumentId);
        if (document == null) throw new ApiException($"{document.Id} nolu Id degeri bulunamadı");

        var newVenueDocument = Mapper.Map<VenueDocument>(input);
        await _venueDocumentRepository.InsertAsync(newVenueDocument);

    }
}
