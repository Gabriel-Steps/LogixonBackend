using LogixonBackend.Domain.Entities;

namespace LogixonBackend.Infra.Repositories.StockMovementsRepositories
{
    public interface IStockMovementsRepository
    {
        public Task<List<StockMovement>> GetAllAsync(CancellationToken cancellationToken);
        public Task<StockMovement?> GetByIdAsync(int id, CancellationToken cancellationToken);
        public Task CreateAsync(StockMovement stockMovement, CancellationToken cancellationToken);
        public Task<List<StockMovement>> GetByProductId(int productId, CancellationToken cancellationToken);
        public Task<List<StockMovement>> GetByUserId(int userId, CancellationToken cancellationToken);
    }
}
