using LogixonBackend.Application.ViewModels.StockMovementsModels;
using MediatR;

namespace LogixonBackend.Application.Queries.StockMovementQueries.GetStockMovementByIdQueries
{
    public class GetStockMovementByIdQuery(int id) : IRequest<StockMovementViewModelDTO>
    {
        public int Id { get; set; } = id;
    }
}
