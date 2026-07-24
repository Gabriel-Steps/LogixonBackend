using LogixonBackend.Application.ViewModels.ProductViewModels;
using MediatR;

namespace LogixonBackend.Application.Queries.ProductQueries.GetProductByLowStockQueries
{
    public class GetProductByLowStockQuery : IRequest<List<ProductViewModelDTO>>
    {
    }
}
