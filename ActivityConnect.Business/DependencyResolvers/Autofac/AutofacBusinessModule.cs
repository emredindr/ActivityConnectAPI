using ActivityConnect.Core.Repositories;
using ActivityConnect.Core.Utilities.Interceptors;
using ActivityConnect.Core.Utilities.Security.JWT;
using ActivityConnect.Core.Utilities.Security.JWT.Configuration;
using ActivityConnect.DataAccess.EntityFrameworkCore.Repositories;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using System.Reflection;
using Module = Autofac.Module;

namespace ActivityConnect.Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //Generic Repo
            builder.RegisterGeneric(typeof(Repository<,>)).As(typeof(IRepository<,>)).InstancePerDependency();
            builder.RegisterType<JwtAuthenticationManager>().As<IJwtAuthenticationManager>().SingleInstance();
            builder.RegisterType<JwtConfiguration>().As<IJwtConfiguration>().SingleInstance();



            //Aspect Oriented Programming
            var assembly = Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly)
                .AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions { Selector = new AspectInterceptorSelector() })
                .InstancePerLifetimeScope();

        }
    }
}