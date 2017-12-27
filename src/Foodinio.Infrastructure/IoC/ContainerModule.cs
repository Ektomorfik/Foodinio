using Autofac;
using Foodinio.Core.Repositories;
using Foodinio.Infrastructure.IoC.Modules;
using Foodinio.Infrastructure.Mappers;
using Foodinio.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;

namespace Foodinio.Infrastructure.IoC
{
    public class ContainerModule : Autofac.Module
    {
        private readonly IConfiguration _configuration;

        public ContainerModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(AutoMapperConfig.Initialize())
                .SingleInstance();
            builder.RegisterModule(new SettingsModule(_configuration));

            builder.RegisterModule<RepositoryModule>();
            builder.RegisterModule<ServiceModule>();
            builder.RegisterModule<CommandModule>();
        }
    }
}