using MediatR;

namespace LogixonBackend.Application.Commands.StockMovementCommands.CreateStockMovementCommands
{
    public class CreateStockMovementCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Type { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public string Reason { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
        public int ProductId { get; set; }
        public int UserId { get; set; }
    }
}
