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

        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     modelBuilder.Entity<User>().ToTable("Users");
        // }
    }
}