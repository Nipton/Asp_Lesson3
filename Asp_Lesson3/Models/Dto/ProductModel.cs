namespace Asp_Lesson3.Models.Dto
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; } = null;
        public int? ProductGroupId { get; set; }
        public double? Price { get; set; }
    }
}
