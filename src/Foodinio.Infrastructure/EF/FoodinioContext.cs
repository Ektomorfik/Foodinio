using Foodinio.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace Foodinio.Infrastructure.EF
{
    public class FoodinioContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<DeliveryAddress> DeliveryAddresses { get; set; }
        public DbSet<BlanketOrder> BlanketOrders { get; set; }
        public DbSet<Order> Orders { get; set; }
        private readonly SqlSettings _settings;

        public FoodinioContext(DbContextOptions<FoodinioContext> options, SqlSettings settings) : base(options)
        {
            _settings = settings;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_settings.ConnectionString, x => x.MigrationsAssembly(_settings.MigrationsAssembly));
        }
    }
}