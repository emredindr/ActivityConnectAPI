using ActivityConnect.Business.Abstract;
using ActivityConnect.Business.ValidationRules.FluentValidation.ActivityDocument;
using ActivityConnect.Core.Aspects.AutoFac.Validation;
using ActivityConnect.Core.DbModels;
using ActivityConnect.Core.Extensions.ResponseAndExceptionMiddleware;
using ActivityConnect.Core.Repositories;
using ActivityConnect.Core.ViewModels.ActivityDocumentVM;

namespace ActivityConnect.Business.Concreate;

public class ActivityDocumentAppService : BaseAppService, IActivityDocumentAppService
{
    private readonly IRepository<Activity, int> _activityRepository;
    private readonly IRepository<ActivityDocument, int> _activityDocumentRepository;
    private readonly IRepository<Document, int> _documentRepository;

    public ActivityDocumentAppService(IRepository<Activity, int> activityRepository, IRepository<ActivityDocument, int> activityDocumentRepository, IRepository<Document, int> documentRepository)
    {
        _activityRepository = activityRepository;
        _activityDocumentRepository = activityDocumentRepository;
        _documentRepository = documentRepository;
    }

    [ValidationAspect(typeof(CreateActivityDocumentInputValidator))]
    public async Task CreateActivityDocument(CreateActivityDocumentInput input)
    {
        var activity = await _activityRepository.FirstOrDefaultAsync(x=>x.Id==input.ActivityId);

        if (activity == null) throw new ApiException($"{input.ActivityId} nolu etkinlik bulunamadı");

        var document = await _documentRepository.FirstOrDefaultAsync(x => x.Id == input.DocumentId);

        if (document == null) throw new ApiException($"{input.DocumentId} nolu Id degeri bulunamadı");

        var newActivityDocument=Mapper.Map<ActivityDocument>(input);
        
        await _activityDocumentRepository.InsertAsync(newActivityDocument);
    }
}
