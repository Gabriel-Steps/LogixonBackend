using LogixonBackend.Application.ViewModels.CategoryViewModels;
using LogixonBackend.Infra.Repositories.CategoryRepositories;
using MediatR;

namespace LogixonBackend.Application.Queries.CategoryQueries.GetAllCategoryQueries
{
    public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQuery, List<CategoryViewModelDTO>>
    {
        private readonly ICategoryRepository _repository;

        public GetAllCategoryQueryHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<CategoryViewModelDTO>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            var categories = await _repository.GetAllAsync(cancellationToken);
            return categories.Select(c => new CategoryViewModelDTO
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description
            }).ToList();
        }
    }
}
