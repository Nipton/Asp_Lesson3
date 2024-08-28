using Microsoft.EntityFrameworkCore;

namespace Asp_Lesson3.Models
{
    public class ProductsDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductGroup> ProductGroups { get; set; }
        public DbSet<Store> Stores { get; set; }
        public ProductsDbContext() { }
        public ProductsDbContext(DbContextOptions<ProductsDbContext> options) : base(options) { }
    }
}
