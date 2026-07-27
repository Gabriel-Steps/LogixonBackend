using LogixonBackend.Domain.Entities;

namespace LogixonBackend.Infra.Repositories.SupplierRepositories
{
    public interface ISupplierRepository
    {
        public Task<List<Supplier>> GetAllAsync(CancellationToken cancellationToken);
        public Task<Supplier?> GetByIdAsync(int id, CancellationToken cancellationToken);
        public Task CreateAsync(Supplier supplier, CancellationToken cancellationToken);
        public Task UpdateAsync(Supplier supplier, CancellationToken cancellationToken);
        public Task DeleteAsync(Supplier supplier, CancellationToken cancellationToken);
    }
}
