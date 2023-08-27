using Microsoft.AspNetCore.Builder;

namespace ActivityConnect.Core.Extensions.ResponseAndExceptionMiddleware
{
    public static class ApiResponseMiddlewareExtension
    {
        public static IApplicationBuilder UseApiResponseAndExceptionWrapper(this IApplicationBuilder builder, ApiResponseOptions options = default)
        {
            options ??= new ApiResponseOptions();
            return builder.UseMiddleware<ApiResponseMiddleware>(options);
        }
    }
}
