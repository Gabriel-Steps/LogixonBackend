using LogixonBackend.Domain.Entities;

namespace LogixonBackend.Infra.Repositories.ProductRepositories
{
    public interface IProductRepository
    {
        public Task<List<Product>> GetAllAsync(CancellationToken cancellationToken);
        public Task<Product?> GetByIdAsync(int id, CancellationToken cancellationToken);
        public Task CreateAsync(Product product, CancellationToken cancellationToken);
        public Task UpdateAsync(Product product, CancellationToken cancellationToken);
        public Task DeleteAsync(Product product, CancellationToken cancellationToken);
        public Task<List<Product>> GetByCategoryIdAsync(int categoryId, CancellationToken cancellationToken);
        public Task<List<Product>> GetByLowStock(CancellationToken cancellationToken);
    }
}
