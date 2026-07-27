using LogixonBackend.Application.Exceptions.SupplierExceptions;
using LogixonBackend.Infra.Repositories.SupplierRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogixonBackend.Application.Commands.SupplierCommands.UpdateSupplierCommands
{
    public class UpdateSupplierCommandHandler : IRequestHandler<UpdateSupplierCommand, Unit>
    {
        private readonly ISupplierRepository _repository;

        public UpdateSupplierCommandHandler(ISupplierRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateSupplierCommand request, CancellationToken cancellationToken)
        {
            var supplier = await _repository.GetByIdAsync(request.Id, cancellationToken) ??
                throw new NotFoundSupplierByIdException(request.Id);

            supplier.Name = request.Name;
            supplier.Email = request.Email;
            supplier.Phone = request.Phone;
            supplier.Address = request.Address;

            await _repository.UpdateAsync(supplier, cancellationToken);

            return Unit.Value;
        }
    }
}
