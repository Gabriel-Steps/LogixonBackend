using LogixonBackend.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LogixonBackend.Infra.Repositories.StockMovementsRepositories
{
    public class StockMovementsRepository : IStockMovementsRepository
    {
        private readonly ProjectLogixonDbContext _context;

        public StockMovementsRepository(ProjectLogixonDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(StockMovement stockMovement, CancellationToken cancellationToken)
        {
            await _context.StockMovements.AddAsync(stockMovement, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public Task<List<StockMovement>> GetAllAsync(CancellationToken cancellationToken)
        {
            return _context.StockMovements.AsNoTracking().ToListAsync(cancellationToken);
        }

        public async Task<StockMovement?> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.StockMovements.SingleOrDefaultAsync(sm => sm.Id == id, cancellationToken);
        }

        public async Task<List<StockMovement>> GetByProductId(int productId, CancellationToken cancellationToken)
        {
            return await _context.StockMovements
                .Where(sm => sm.ProductId == productId)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        public async Task<List<StockMovement>> GetByUserId(int userId, CancellationToken cancellationToken)
        {
            return await _context.StockMovements
                .Where(sm => sm.UserId == userId)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }
    }
}
