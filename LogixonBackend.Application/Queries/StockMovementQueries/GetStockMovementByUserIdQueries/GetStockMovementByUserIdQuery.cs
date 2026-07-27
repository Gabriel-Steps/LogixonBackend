using LogixonBackend.Application.ViewModels.StockMovementsModels;
using MediatR;

namespace LogixonBackend.Application.Queries.StockMovementQueries.GetStockMovementByUserIdQueries
{
    public class GetStockMovementByUserIdQuery(int id) : IRequest<List<StockMovementViewModelDTO>>
    {
        public int Id { get; set; } = id;
    }
}
