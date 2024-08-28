using Microsoft.EntityFrameworkCore;
using Warehouse.Models;

namespace Warehouse.Services
{
    public class WarehouseDbContext : DbContext
    {
        public DbSet<WarehouseEntity> Warehouses { get; set; }
        public WarehouseDbContext() { }
        public WarehouseDbContext(DbContextOptions<WarehouseDbContext> options) : base(options) { }
    }
}
