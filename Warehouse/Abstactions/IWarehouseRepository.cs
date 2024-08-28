using Warehouse.Models;

namespace Warehouse.Abstactions
{
    public interface IWarehouseRepository
    {
        int Create(WarehouseDto warehouse);
        IEnumerable<WarehouseDto> GetAll();
        WarehouseDto Update(int id, int newQuantity, string name);
        WarehouseDto? GetWarehouse(int id);
    }
}
