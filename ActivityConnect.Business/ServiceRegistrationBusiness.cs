using ActivityConnect.Core.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace ActivityConnect.Business
{
    public static class ServiceRegistrationBusiness
    {
        public static void AddDependencyResolver(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IUserManager, UserManager>();
        }
    }
}
