using System;
using System.Linq;
using Foodinio.Infrastructure.EF;
using Microsoft.Extensions.Configuration;

namespace Foodinio.Infrastructure.Extensions
{
    public static class SettingsExtensions
    {
        public static SqlSettings GetSqlSettings(this IConfiguration configuration)
        {
            var connectionString = configuration["sql:connectionString"];
            var migrationsAssembly = configuration["sql:migrationsAssembly"];
            var settings = new SqlSettings(connectionString, migrationsAssembly);
            return settings;
        }
    }
}