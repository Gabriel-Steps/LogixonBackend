using LogixonBackend.Application.ViewModels.SupplierViewModels;
using LogixonBackend.Domain.Entities;
using LogixonBackend.Infra.Repositories.SupplierRepositories;
using MediatR;

namespace LogixonBackend.Application.Queries.SupplierQueries.GetAllSupplierQueries
{
    public class GetAllSupplierQueryHandler : IRequestHandler<GetAllSupplierQuery, List<SupplierViewModelDTO>>
    {
        private readonly ISupplierRepository _repository;

        public GetAllSupplierQueryHandler(ISupplierRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<SupplierViewModelDTO>> Handle(GetAllSupplierQuery request, CancellationToken cancellationToken)
        {
            var suppliers = await _repository.GetAllAsync(cancellationToken);
            return suppliers.Select(s => new SupplierViewModelDTO()
            {
                Id = s.Id,
                Name = s.Name,
                Email = s.Email,
                Phone = s.Phone,
                Address = s.Address,
                IsActive = s.IsActive
            }).ToList();
        }
    }
}
