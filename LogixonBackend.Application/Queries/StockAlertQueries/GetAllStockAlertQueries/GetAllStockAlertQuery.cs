using LogixonBackend.Application.ViewModels.StockAlertViewModels;
using MediatR;

namespace LogixonBackend.Application.Queries.StockAlertQueries.GetAllStockAlertQueries
{
    public class GetAllStockAlertQuery : IRequest<List<StockAlertViewModelDTO>>
    {
    }
}
