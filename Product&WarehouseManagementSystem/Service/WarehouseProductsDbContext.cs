using Microsoft.EntityFrameworkCore;
using Product_WarehouseManagementSystem.Models;

namespace Product_WarehouseManagementSystem.Service
{
    public class WarehouseProductsDbContext : DbContext
    {
        public DbSet<WarehouseProduct> WarehouseProducts { get; set; }
        public WarehouseProductsDbContext()
        {
        }
        public WarehouseProductsDbContext(DbContextOptions<WarehouseProductsDbContext> options) : base(options) { }
    }
}
