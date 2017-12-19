using Autofac;
using Foodinio.Core.Repositories;
using Foodinio.Infrastructure.IoC.Modules;
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
            builder.RegisterModule<RepositoryModule>();
        }
    }
}