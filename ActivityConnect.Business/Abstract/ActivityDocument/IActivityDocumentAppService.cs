using ActivityConnect.Core.ViewModels.ActivityDocumentVM;

namespace ActivityConnect.Business.Abstract;

public interface IActivityDocumentAppService
{
    Task CreateActivityDocument(CreateActivityDocumentInput input);
}
