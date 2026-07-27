using MediatR;

namespace LogixonBackend.Application.Commands.StockAlertCommands.CreateStockAlertCommands
{
    public class CreateStockAlertCommand : IRequest<Unit>
    {
        public string AlertType { get; set; } = string.Empty;
        public int ProductId { get; set; }
    }
}
