using System;
using System.Collections.Generic;
using System.Text;

namespace LogixonBackend.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string SKU { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int QuantityInStock { get; set; }
        public int MinimumStock { get; set; }
        public int MaximumStock { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        public int CategoryId { get; set; }
        public int SupplierId { get; set; }

        public Category Category { get; set; }
        public Supplier Supplier { get; set; }
        public ICollection<StockMovement> StockMovements { get; set; }
        public ICollection<StockAlert> Alerts { get; set; }
    }
}
