using HotChocolate;
using Product_WarehouseManagementSystem.Abstractions;
using Product_WarehouseManagementSystem.Client;
using Product_WarehouseManagementSystem.Models;

namespace Product_WarehouseManagementSystem.Query
{
    public class WarhouseProductsQuery
    {
        public IEnumerable<WarehouseProductDto> GetAllRecords([Service] IWarehouseProductsRepository repository)
        {
            return repository.GetAllWarehouseProducts();
        }
        public async Task<bool> GetProduct(int id)
        {
            var t = await ProductsClient.Exists(id);
            return t;
        }
        public async Task<bool> GetWarehouse(int id)
        {
            var t = await WarehouseClient.Exists(id);
            return t;
        }
    }
}
