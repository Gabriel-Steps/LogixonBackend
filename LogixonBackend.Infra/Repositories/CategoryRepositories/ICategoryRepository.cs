using LogixonBackend.Domain.Entities;

namespace LogixonBackend.Infra.Repositories.CategoryRepositories
{
    public interface ICategoryRepository
    {
        public Task<List<Category>> GetAllAsync(CancellationToken cancellationToken);
        public Task<Category?> GetByIdAsync(int id, CancellationToken cancellationToken);
        public Task CreateAsync(Category category, CancellationToken cancellationToken);
        public Task UpdateAsync(Category category, CancellationToken cancellationToken);
        public Task DeleteAsync(Category category, CancellationToken cancellationToken);
    }
}
