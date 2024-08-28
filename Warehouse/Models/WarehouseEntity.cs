
using System.ComponentModel.DataAnnotations.Schema;

namespace Warehouse.Models
{
    public class WarehouseEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; } = null;
        public int Capacity { get; set; }
        public DateTime DateReceived { get; set; }
    }
}
