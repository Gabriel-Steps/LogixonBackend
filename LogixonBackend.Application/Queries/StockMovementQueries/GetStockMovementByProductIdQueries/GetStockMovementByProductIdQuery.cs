using LogixonBackend.Application.ViewModels.StockMovementsModels;
using MediatR;

namespace LogixonBackend.Application.Queries.StockMovementQueries.GetStockMovementByProductIdQueries
{
    public class GetStockMovementByProductIdQuery(int id) : IRequest<List<StockMovementViewModelDTO>>
    {
        public int Id { get; set; } = id;
    }
}
