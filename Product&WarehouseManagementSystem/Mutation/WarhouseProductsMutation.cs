using HotChocolate;
using Product_WarehouseManagementSystem.Abstractions;
using Product_WarehouseManagementSystem.Client;
using Product_WarehouseManagementSystem.Models;

namespace Product_WarehouseManagementSystem.Mutation
{
    public class WarhouseProductsMutation
    {
        public async Task<CreateRecordResultDto> AddRecord([Service] IWarehouseProductsRepository repository, WarehouseProductDto warehouseProductDto)
        {
            var productExistsTask = ProductsClient.Exists(warehouseProductDto.ProductId);
            var warehouseExistsTask = WarehouseClient.Exists(warehouseProductDto.WarehouseId);
            var productExists = await productExistsTask;
            var warehouseExists = await warehouseExistsTask;
            if (productExists && warehouseExists)
            {
                try
                {
                    repository.AddProductToWarehouse(warehouseProductDto);
                    return new CreateRecordResultDto() { Success = true };
                }
                catch (Exception ex)
                {
                    return new CreateRecordResultDto() { Error = ex.Message };
                }
            }
            else
            {
                if (!productExists)
                {
                    return new CreateRecordResultDto() { Error = "Продукт не найден" };
                }
                else if (!warehouseExists)
                {
                    return new CreateRecordResultDto() { Error = "Склад не найден" };
                }
            }
            return new CreateRecordResultDto() { Error = "Неизвестная ошибка" };
        }
        public int DeleteRecord([Service] IWarehouseProductsRepository repository, int id)
        {
            repository.DeleteRecord(id);
            return 0;
        }
    }
}
