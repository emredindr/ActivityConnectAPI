using ActivityConnect.Business.Abstract;
using ActivityConnect.Core.Extensions.ResponseAndExceptionMiddleware;
using ActivityConnect.Core.ViewModels.DocumentVM;
using Firebase.Storage;
using Microsoft.AspNetCore.Mvc;

namespace ActivityConnect.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DocumentController : BaseController
{

    private readonly IDocumentAppService _documentAppService;
    public DocumentController(IDocumentAppService documentAppService, IConfiguration configuration)
    {
        _documentAppService = documentAppService;
    }

    [HttpPost("UploadDocumentToFirebaseStorage")]
    public async Task<IActionResult> UploadDocumentToFirebaseStorage()
    {
        Random random = new();
        var asd = random.Next(101, 1000);
        try
        {
            var file = Request.Form.Files[0];

            if (file == null)
            {
                return BadRequest();
            }

            string fileExtension = Path.GetExtension(file.FileName);

            string result = file.FileName.Substring(0, file.FileName.Length - fileExtension.Length);

            string fileName = result + "-" + asd.ToString();


            string newFileName = string.Join(string.Empty, fileName, fileExtension);

            var stream = file.OpenReadStream();

            var task = new FirebaseStorage("archive-ed.appspot.com", new FirebaseStorageOptions
            {
                ThrowOnCancel = true
            }).Child("activity-connect").Child(newFileName).PutAsync(stream);

            string url = await task;

            var recordDocumentId = await _documentAppService.CreateAndGetDocumentIdFirebase(newFileName, file.ContentType, url);

            return Ok(new UploadedDocumentInfo
            {
                DocumentId = recordDocumentId,
                DocumentName = newFileName,
                DocumentUrl = url
            });
        }
        catch (Exception ex)
        {
            throw new ApiException(ex);
        }
    }

    [HttpPost("UploadDocumentsToFirebaseStorage")]
    public async Task<IActionResult> UploadDocumentsToFirebaseStorage()
    {
        Random random = new();
        var asd = random.Next(101, 1000);
        try
        {
            var files = Request.Form.Files;

            if (files == null || !files.Any())
            {
                return BadRequest();
            }

            var uploadedDocumentList = new List<UploadedDocumentInfo>();

            foreach (var file in files)
            {
                string fileExtension = Path.GetExtension(file.FileName);

                string result = file.FileName.Substring(0, file.FileName.Length - fileExtension.Length);

                string fileName = result + "-" + asd.ToString();


                string newFileName = string.Join(string.Empty, fileName, fileExtension);

                var stream = file.OpenReadStream();

                var task = new FirebaseStorage("archive-ed.appspot.com", new FirebaseStorageOptions
                {
                    ThrowOnCancel = true
                }).Child("activity-connect").Child(newFileName).PutAsync(stream);

                string url = await task;

                var recordDocumentId = await _documentAppService.CreateAndGetDocumentIdFirebase(newFileName, file.ContentType, url);

                uploadedDocumentList.Add(new UploadedDocumentInfo
                {
                    DocumentId = recordDocumentId,
                    DocumentName = newFileName,
                    DocumentUrl = url
                });
            }

            return Ok(uploadedDocumentList);
        }
        catch (Exception ex)
        {
            throw new ApiException(ex);
        }
    }
}

