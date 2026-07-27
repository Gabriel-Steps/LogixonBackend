using LogixonBackend.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LogixonBackend.Infra.Repositories.StockAlertRepositories
{
    public class StockAlertRepository : IStockAlertRepository
    {
        private readonly ProjectLogixonDbContext _context;

        public StockAlertRepository(ProjectLogixonDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(StockAlert stockAlert, CancellationToken cancellationToken)
        {
            await _context.StockAlerts.AddAsync(stockAlert, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(StockAlert stockAlert, CancellationToken cancellationToken)
        {
            _context.StockAlerts.Remove(stockAlert);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<StockAlert>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.StockAlerts.AsNoTracking().ToListAsync(cancellationToken);
        }

        public async Task<StockAlert?> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.StockAlerts.SingleOrDefaultAsync(sa => sa.Id == id, cancellationToken);
        }
    }
}
