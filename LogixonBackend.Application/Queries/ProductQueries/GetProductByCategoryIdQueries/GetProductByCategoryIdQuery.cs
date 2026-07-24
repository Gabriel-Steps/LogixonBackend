using LogixonBackend.Application.ViewModels.ProductViewModels;
using MediatR;

namespace LogixonBackend.Application.Queries.ProductQueries.GetProductByCategoryIdQueries
{
    public class GetProductByCategoryIdQuery(int id) : IRequest<List<ProductViewModelDTO>>
    {
        public int Id { get; set; } = id;
    }
}
