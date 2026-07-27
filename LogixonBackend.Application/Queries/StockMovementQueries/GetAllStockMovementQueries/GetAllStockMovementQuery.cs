using LogixonBackend.Application.ViewModels.StockMovementsModels;
using MediatR;

namespace LogixonBackend.Application.Queries.StockMovementQueries.GetAllStockMovementQueries
{
    public class GetAllStockMovementQuery : IRequest<List<StockMovementViewModelDTO>>
    { }
}
