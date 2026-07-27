using LogixonBackend.Application.Exceptions.SupplierExceptions;
using LogixonBackend.Application.ViewModels.SupplierViewModels;
using LogixonBackend.Infra.Repositories.SupplierRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogixonBackend.Application.Queries.SupplierQueries.GetSupplierByIdQueries
{
    public class GetSupplierByIdQueryHandler : IRequestHandler<GetSupplierByIdQuery, SupplierViewModelDTO>
    {
        private readonly ISupplierRepository _repository;

        public GetSupplierByIdQueryHandler(ISupplierRepository repository)
        {
            _repository = repository;
        }

        public async Task<SupplierViewModelDTO> Handle(GetSupplierByIdQuery request, CancellationToken cancellationToken)
        {
            var supplier = await _repository.GetByIdAsync(request.Id, cancellationToken) ??
                throw new NotFoundSupplierByIdException(request.Id);

            return new SupplierViewModelDTO()
            {
                Id = supplier.Id,
                Name = supplier.Name,
                Email = supplier.Email,
                Phone = supplier.Phone,
                Address = supplier.Address,
                IsActive = supplier.IsActive
            };
        }
    }
}
