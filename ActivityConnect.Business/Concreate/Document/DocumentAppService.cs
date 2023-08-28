using ActivityConnect.Business.Abstract;
using ActivityConnect.Core.DbModels;
using ActivityConnect.Core.Repositories;

namespace ActivityConnect.Business.Concreate;

public class DocumentAppService : BaseAppService, IDocumentAppService
{
    private readonly IRepository<Document, int> _documentrepository;
    public DocumentAppService(IRepository<Document, int> documentrepository)
    {
        _documentrepository = documentrepository;
    }

    public async Task<int> CreateAndGetDocumentId(string fileName, string contentType)
    {
        return await _documentrepository.InsertAndGetIdAsync(new Document() { Name = fileName, ContentType = contentType });
    }
    public async Task<int> CreateAndGetDocumentIdFirebase(string fileName, string contentType, string url)
    {
        var asd = await _documentrepository.InsertAndGetIdAsync(new Document() { Name = fileName, ContentType = contentType, Url = url });
        return asd;
    }
}
