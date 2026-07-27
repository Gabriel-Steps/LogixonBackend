namespace LogixonBackend.Domain.Entities
{
    public class StockAlert
    {
        public int Id { get; set; }
        public string AlertType { get; set; } = string.Empty; // "LowStock" ou "HighStock"
        public DateTime AlertDate { get; set; } = DateTime.UtcNow;

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
