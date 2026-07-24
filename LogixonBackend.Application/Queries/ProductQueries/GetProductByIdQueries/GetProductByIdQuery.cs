using LogixonBackend.Application.ViewModels.ProductViewModels;
using MediatR;

namespace LogixonBackend.Application.Queries.ProductQueries.GetProductByIdQueries
{
    public class GetProductByIdQuery(int id) : IRequest<ProductViewModelDTO>
    {
        public int Id { get; set; } = id;
    }
}
