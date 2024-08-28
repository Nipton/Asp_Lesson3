using HotChocolate;
using Warehouse.Abstactions;
using Warehouse.Models;

namespace Warehouse.Query
{
    public class WarehouseQuery
    {
        public IEnumerable<WarehouseDto> GetAllRecords([Service] IWarehouseRepository repository)
        {
            return repository.GetAll();
        }
        public bool ExistById(int id, [Service] IWarehouseRepository repository)
        {
            if(repository.GetWarehouse(id) != null)
                return true;
            return false;
        }
    }
}
