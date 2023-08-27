using ActivityConnect.Core.Utilities.Interceptors;
using Castle.DynamicProxy;
using ActivityConnect.Core.Extensions.ResponseAndExceptionMiddleware;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace ActivityConnect.Core.Aspects.AutoFac.Authorize
{
    public class AuthorizeAspect : MethodInterception
    {
        private readonly string[] _permissions;
        public AuthorizeAspect(params string[] permissions)
        {
            _permissions = permissions;
        }

        protected override void OnBefore(IInvocation invocation)
        {
            var _httpContext = new HttpContextAccessor().HttpContext;
            var identity = _httpContext.User.Identity as ClaimsIdentity;
            var userPermissions = identity.FindAll(ClaimTypes.Role).Select(x => x.Value.ToString());

            foreach (var permission in _permissions)
                if (userPermissions.Contains(permission))
                    return;

            throw new ApiException("Bu işlem için yetkiniz bulunmamaktadır");
        }
    }
}
