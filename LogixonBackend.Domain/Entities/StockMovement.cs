namespace LogixonBackend.Domain.Entities
{
    public class StockMovement
    {
        public int Id { get; set; }
        public string Type { get; set; } = string.Empty; // "Entrada" ou "Saída"
        public int Quantity { get; set; }
        public string Reason { get; set; } = string.Empty; // "Compra", "Venda", "Devolução", "Ajuste", etc
        public string Notes { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public int ProductId { get; set; }
        public int UserId { get; set; }

        public Product Product { get; set; }
        public User User { get; set; }
    }
}
