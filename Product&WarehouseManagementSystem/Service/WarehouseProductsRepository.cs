using AutoMapper;
using Product_WarehouseManagementSystem.Abstractions;
using Product_WarehouseManagementSystem.Models;
using System.Xml.Linq;

namespace Product_WarehouseManagementSystem.Service
{
    public class WarehouseProductsRepository : IWarehouseProductsRepository
    {
        private IMapper mapper;
        private WarehouseProductsDbContext db;
        public WarehouseProductsRepository(IMapper mapper, WarehouseProductsDbContext dbContext) 
        {
            this.mapper = mapper;
            db = dbContext;
        }
        public int AddProductToWarehouse(WarehouseProductDto warehouseProductDto)
        {
            using (db)
            {
                var warehouseEntity = mapper.Map<WarehouseProduct>(warehouseProductDto);
                db.WarehouseProducts.Add(warehouseEntity);
                db.SaveChanges();
                return warehouseEntity.Id;
            }
        }

        public void DeleteRecord(int id)
        {
            using (db)
            {
                var warehouseProduct = db.WarehouseProducts.Find(id);
                if (warehouseProduct != null)
                {
                    db.WarehouseProducts.Remove(warehouseProduct);
                    db.SaveChanges();
                }
            }
        }

        public IEnumerable<WarehouseProductDto> GetAllWarehouseProducts()
        {
            using(db)
                return db.WarehouseProducts.Select(x => mapper.Map<WarehouseProductDto>(x)).ToList();
        }
    }
}
