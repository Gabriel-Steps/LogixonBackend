using LogixonBackend.Domain.Entities;

namespace LogixonBackend.Infra.Repositories.StockAlertRepositories
{
    public interface IStockAlertRepository
    {
        public Task<List<StockAlert>> GetAllAsync(CancellationToken cancellationToken);
        public Task<StockAlert?> GetByIdAsync(int id, CancellationToken cancellationToken);
        public Task DeleteAsync(StockAlert stockAlert, CancellationToken cancellationToken);
        public Task CreateAsync(StockAlert stockAlert, CancellationToken cancellationToken);
    }
}
