using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace ActivityConnect.Core.Extensions.ResponseAndExceptionMiddleware
{
    [DataContract]
    public class ApiResponse
    {
        [DataMember]
        public string Version { get; set; }

        [DataMember]
        public int StatusCode { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string Message { get; set; }

        [DataMember]
        public bool IsError { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public ApiError ResponseException { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public object Result { get; set; }

        [JsonConstructor]
        public ApiResponse(string message, object result = null, int statusCode = 200, string apiVersion = "1.0.0.0")
        {
            StatusCode = statusCode;
            Message = message;
            Result = result;
            Version = apiVersion;
            IsError = false;
        }
        [JsonConstructor]
        public ApiResponse(int statusCode, ApiError apiError)
        {
            StatusCode = statusCode;
            ResponseException = apiError;
            IsError = true;
        }
    }
}
