﻿namespace Asp_Lesson3.Models
{
    public class Store
    {
        public int Id { get; set; }
        public string? Name { get; set; } = null;
        public int Quantity { get; set; }
        public int? ProductId { get; set; }
        public virtual Product? Product { get; set; }

    }
}
