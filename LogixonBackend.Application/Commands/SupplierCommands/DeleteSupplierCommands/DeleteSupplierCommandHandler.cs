using LogixonBackend.Application.Exceptions.SupplierExceptions;
using LogixonBackend.Infra.Repositories.SupplierRepositories;
using MediatR;

namespace LogixonBackend.Application.Commands.SupplierCommands.DeleteSupplierCommands
{
    public class DeleteSupplierCommandHandler : IRequestHandler<DeleteSupplierCommand, Unit>
    {
        private readonly ISupplierRepository _repository;

        public DeleteSupplierCommandHandler(ISupplierRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteSupplierCommand request, CancellationToken cancellationToken)
        {
            var supplier = await _repository.GetByIdAsync(request.Id, cancellationToken) ??
                throw new NotFoundSupplierByIdException(request.Id);

            await _repository.DeleteAsync(supplier, cancellationToken);

            return Unit.Value;
        }
    }
}
