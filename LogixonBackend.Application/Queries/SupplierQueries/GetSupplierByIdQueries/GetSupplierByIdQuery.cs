using LogixonBackend.Application.ViewModels.SupplierViewModels;
using MediatR;

namespace LogixonBackend.Application.Queries.SupplierQueries.GetSupplierByIdQueries
{
    public class GetSupplierByIdQuery(int id) : IRequest<SupplierViewModelDTO>
    {
        public int Id { get; set; } = id;
    }
}
