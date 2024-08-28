namespace Product_WarehouseManagementSystem.Client
{
    public interface IClient
    {
        Task<bool> Exists(int id);
    }
}
