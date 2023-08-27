namespace ActivityConnect.Core.Extensions.ResponseAndExceptionMiddleware
{
    public class ApiError
    {
        public string ExceptionMessage { get; set; }
        public string Details { get; set; }
        public string ReferenceErrorCode { get; set; }
        public string ReferenceDocumentLink { get; set; }
        public IEnumerable<ValidationError> ValidationErrors { get; set; }

        public ApiError(string message)
        {
            ExceptionMessage = message;
        }

        public ApiError(string message, IEnumerable<ValidationError> validationErrors)
        {
            ExceptionMessage = message;
            ValidationErrors = validationErrors;
        }
    }
}
