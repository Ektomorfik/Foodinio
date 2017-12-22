namespace Foodinio.Infrastructure.EF
{
    public class SqlSettings
    {
        public string ConnectionString { get; set; }
        public string MigrationsAssembly { get; set; }
        public SqlSettings(string connectionString, string migrationsAssembly)
        {
            ConnectionString = connectionString;
            MigrationsAssembly = migrationsAssembly;
        }
    }
}