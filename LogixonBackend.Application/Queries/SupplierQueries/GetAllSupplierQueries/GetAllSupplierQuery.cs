using LogixonBackend.Application.ViewModels.SupplierViewModels;
using MediatR;

namespace LogixonBackend.Application.Queries.SupplierQueries.GetAllSupplierQueries
{
    public class GetAllSupplierQuery : IRequest<List<SupplierViewModelDTO>>
    {
    }
}
