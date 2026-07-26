using LogixonBackend.Domain.Entities;
using LogixonBackend.Infra.Repositories.CategoryRepositories;
using MediatR;

namespace LogixonBackend.Application.Commands.CategoryCommands.CreateCategoryCommands
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Unit>
    {
        private readonly ICategoryRepository _categoryRepository;

        public CreateCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Unit> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = new Category
            {
                Name = request.Name,
                Description = request.Description,
                CreatedAt = DateTime.UtcNow
            };
            await _categoryRepository.CreateAsync(category, cancellationToken);
            return Unit.Value;
        }
    }
}
