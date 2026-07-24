using LogixonBackend.Application.ViewModels.ProductViewModels;
using MediatR;

namespace LogixonBackend.Application.Queries.ProductQueries.GetAllProductQueries
{
    public class GetAllProductQuery : IRequest<List<ProductViewModelDTO>>
    {
    }
}
