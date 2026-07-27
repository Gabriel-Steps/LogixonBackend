using LogixonBackend.Domain.Entities;
using LogixonBackend.Infra.Repositories.SupplierRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogixonBackend.Application.Commands.SupplierCommands.CreateSupplierCommands
{
    public class CreateSupplierCommandHandler : IRequestHandler<CreateSupplierCommand, Unit>
    {
        private readonly ISupplierRepository _repository;

        public CreateSupplierCommandHandler(ISupplierRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CreateSupplierCommand request, CancellationToken cancellationToken)
        {
            var supplier = new Supplier()
            {
                Name = request.Name,
                Email = request.Email,
                Phone = request.Phone,
                Address = request.Address,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };

            await _repository.CreateAsync(supplier, cancellationToken);
            return Unit.Value;
        }
    }
}
