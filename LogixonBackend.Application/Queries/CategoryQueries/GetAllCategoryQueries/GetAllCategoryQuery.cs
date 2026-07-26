using LogixonBackend.Application.ViewModels.CategoryViewModels;
using MediatR;

namespace LogixonBackend.Application.Queries.CategoryQueries.GetAllCategoryQueries
{
    public class GetAllCategoryQuery : IRequest<List<CategoryViewModelDTO>>
    {
    }
}
