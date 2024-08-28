using AutoMapper;
using Warehouse.Abstactions;
using Warehouse.Models;

namespace Warehouse.Services
{
    public class WarehouseRepository : IWarehouseRepository
    {
        private readonly IMapper mapper;
        private readonly WarehouseDbContext db;
        public WarehouseRepository(IMapper mapper, WarehouseDbContext warehouseDbContext) 
        {
            this.mapper = mapper;
            this.db = warehouseDbContext;
        }
        public int Create(WarehouseDto warehouse)
        {
            using (db)
            {
                var warehouseEntity = mapper.Map<WarehouseEntity>(warehouse);
                warehouseEntity.DateReceived = DateTime.Now;
                db.Warehouses.Add(warehouseEntity);
                db.SaveChanges();
                return warehouseEntity.Id;
            }
        }

        public IEnumerable<WarehouseDto> GetAll()
        {
            using (db)
                return db.Warehouses.Select(x => mapper.Map<WarehouseDto>(x)).ToList();
        }

        public WarehouseDto? GetWarehouse(int id)
        {
            using (db)
            {
                var warehouseEntity = db.Warehouses.Find(id);
                if (warehouseEntity == null)
                {
                    return null;
                }
                else
                {
                    return mapper.Map<WarehouseDto>(warehouseEntity);
                }
            }

        }

        public WarehouseDto Update(int id, int newCapacity, string name)
        {
            using (db)
            {
                var warehouse = db.Warehouses.Find(id);
                if (warehouse != null)
                {
                    warehouse.Capacity = newCapacity;
                    warehouse.Name = name;
                    db.SaveChanges();
                    return mapper.Map<WarehouseDto>(warehouse);
                }
                return null;
            }
        }
    }
}
