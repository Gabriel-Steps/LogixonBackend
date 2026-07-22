namespace LogixonBackend.Domain.Entities
{
    public class StockAlert
    {
        public int Id { get; set; }
        public string AlertType { get; set; } = string.Empty; // "LowStock" ou "HighStock"
        public DateTime AlertDate { get; set; } = DateTime.UtcNow;

        // Chaves estrangeiras
        public int ProductId { get; set; }

        // Relacionamentos
        public Product Product { get; set; }
    }
}
