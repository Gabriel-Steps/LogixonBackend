using LogixonBackend.Application.ViewModels.StockAlertViewModels;
using MediatR;

namespace LogixonBackend.Application.Queries.StockAlertQueries.GetStockAlertByIdQueries
{
    public class GetStockAlertByIdQuery(int id) : IRequest<StockAlertViewModelDTO>
    {
        public int Id { get; set; } = id;
    }
}
