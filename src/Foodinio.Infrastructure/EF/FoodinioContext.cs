using Foodinio.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace Foodinio.Infrastructure.EF
{
    public class FoodinioContext : DbContext
    {
        public FoodinioContext(DbContextOptions<FoodinioContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<DeliveryAddress> DeliveryAddresses { get; set; }
        public DbSet<BlanketOrder> BlanketOrders { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}