using Autofac;
using Foodinio.Infrastructure.EF;
using Foodinio.Infrastructure.Extensions;
using Microsoft.Extensions.Configuration;

namespace Foodinio.Infrastructure.IoC.Modules
{
    public class SettingsModule : Autofac.Module
    {
        private readonly IConfiguration _configuration;

        public SettingsModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(_configuration.GetSqlSettings()).SingleInstance();
            builder.RegisterInstance(_configuration.GetJwtSettings()).SingleInstance();
        }
    }
}