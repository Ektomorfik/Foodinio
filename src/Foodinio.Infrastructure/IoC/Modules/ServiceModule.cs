using System.Reflection;
using Autofac;
using Foodinio.Infrastructure.Services;
using Foodinio.Infrastructure.Services.Encryption;

namespace Foodinio.Infrastructure.IoC.Modules
{
    public class ServiceModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(ServiceModule)
                .GetTypeInfo()
                .Assembly;

            builder.RegisterAssemblyTypes(assembly)
                .Where(x => x.IsAssignableTo<IService>())
                .AsImplementedInterfaces()
                .SingleInstance();

            builder.RegisterType<Encrypter>()
                .As<IEncrypter>()
                .SingleInstance();
        }
    }
}