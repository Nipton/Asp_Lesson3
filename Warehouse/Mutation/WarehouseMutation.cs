using HotChocolate;
using Warehouse.Abstactions;
using Warehouse.Models;

namespace Warehouse.Mutation
{
    public class WarehouseMutation
    {
        public int AddRecord(WarehouseDto warehouseDto, [Service] IWarehouseRepository repository)
        {
            return repository.Create(warehouseDto);
        }
        public WarehouseDto Update(int id, int amount, string name, [Service] IWarehouseRepository repository)
        {
           return repository.Update(id, amount, name);
        }

    }
}
