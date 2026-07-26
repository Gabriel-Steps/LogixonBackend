using LogixonBackend.Application.Exceptions.CategoryExceptions;
using LogixonBackend.Infra.Repositories.CategoryRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogixonBackend.Application.Commands.CategoryCommands.UpdateCategoryCommands
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, Unit>
    {
        private readonly ICategoryRepository _repository;

        public UpdateCategoryCommandHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _repository.GetByIdAsync(request.Id, cancellationToken) ??
                throw new NotFoundCategoryByIdException(request.Id);

            category.Name = request.Name;
            category.Description = request.Description;

            await _repository.UpdateAsync(category, cancellationToken);
            return Unit.Value;
        }
    }
}
