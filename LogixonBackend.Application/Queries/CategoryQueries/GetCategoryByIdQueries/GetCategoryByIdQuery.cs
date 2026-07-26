using LogixonBackend.Application.ViewModels.CategoryViewModels;
using MediatR;

namespace LogixonBackend.Application.Queries.CategoryQueries.GetCategoryByIdQueries
{
    public class GetCategoryByIdQuery(int id) : IRequest<CategoryViewModelDTO>
    {
        public int Id { get; set; } = id;
    }
}
