using MediatR;

namespace LogixonBackend.Application.Commands.StockAlertCommands.DeleteStockAlertCommands
{
    public class DeleteStockAlertCommand(int id) : IRequest<Unit>
    {
        public int Id { get; set; } = id;
    }
}
