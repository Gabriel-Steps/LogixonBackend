using LogixonBackend.Application.Exceptions.CategoryExceptions;
using LogixonBackend.Infra.Repositories.CategoryRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogixonBackend.Application.Commands.CategoryCommands.DeleteCategoryCommands
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, Unit>
    {
        private readonly ICategoryRepository _repository;

        public DeleteCategoryCommandHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _repository.GetByIdAsync(request.Id, cancellationToken) ??
                throw new NotFoundCategoryByIdException(request.Id);

            await _repository.DeleteAsync(category, cancellationToken);

            return Unit.Value;
        }
    }
}
