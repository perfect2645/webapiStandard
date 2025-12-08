using Fawei.Repository.Entities.Shirts;
using Microsoft.EntityFrameworkCore;

namespace Fawei.Repository
{
    public class ShirtsDbContext : DbContext
    {
        public DbSet<Shirt> Shirts { get; set; }

        public ShirtsDbContext(DbContextOptions<ShirtsDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Shirt>().HasData(shirts);
        }
    }
}
