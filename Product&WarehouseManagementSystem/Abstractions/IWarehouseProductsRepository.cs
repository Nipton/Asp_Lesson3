using Product_WarehouseManagementSystem.Models;

namespace Product_WarehouseManagementSystem.Abstractions
{
    public interface IWarehouseProductsRepository
    {
        int AddProductToWarehouse(WarehouseProductDto warehouseProductDto);
        IEnumerable<WarehouseProductDto> GetAllWarehouseProducts();
        void DeleteRecord(int id);

    }
}
