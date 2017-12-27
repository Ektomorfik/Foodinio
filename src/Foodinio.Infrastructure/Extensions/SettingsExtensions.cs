using System;
using System.Linq;
using Foodinio.Infrastructure.EF;
using Foodinio.Infrastructure.Settings;
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
        public static JwtSettings GetJwtSettings(this IConfiguration configuration)
        {
            var key = configuration["jwt:Key"];
            var issuer = configuration["jwt:Issuer"];
            int expiryMinutes = Int32.Parse(configuration["jwt:ExpiryMinutes"]);
            var settings = new JwtSettings(key, issuer, expiryMinutes);
            return settings;

        }
    }
}