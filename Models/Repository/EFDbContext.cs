using System.Data.Entity;

namespace Automobile_repair_shop.Models.Repository
{
    public class EFDbContext : DbContext
    {
        public DbSet<Service> Services { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}