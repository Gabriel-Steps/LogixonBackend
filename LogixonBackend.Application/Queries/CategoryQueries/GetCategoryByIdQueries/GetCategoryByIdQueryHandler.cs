using LogixonBackend.Application.Exceptions.CategoryExceptions;
using LogixonBackend.Application.ViewModels.CategoryViewModels;
using LogixonBackend.Infra.Repositories.CategoryRepositories;
using MediatR;

namespace LogixonBackend.Application.Queries.CategoryQueries.GetCategoryByIdQueries
{
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, CategoryViewModelDTO>
    {
        private readonly ICategoryRepository _categoryRepository;
        public GetCategoryByIdQueryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<CategoryViewModelDTO> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(request.Id, cancellationToken) ??
                throw new NotFoundCategoryByIdException(request.Id);
            return new CategoryViewModelDTO
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description
            };
        }
    }
}
