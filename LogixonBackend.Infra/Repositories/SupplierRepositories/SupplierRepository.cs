using LogixonBackend.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LogixonBackend.Infra.Repositories.SupplierRepositories
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly ProjectLogixonDbContext _context;

        public SupplierRepository(ProjectLogixonDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Supplier supplier, CancellationToken cancellationToken)
        {
            await _context.Suppliers.AddAsync(supplier, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(Supplier supplier, CancellationToken cancellationToken)
        {
            _context.Suppliers.Remove(supplier);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<Supplier>> GetAllAsync(CancellationToken cancellationToken)
        {

            return await _context.Suppliers.AsNoTracking().ToListAsync(cancellationToken);
        }

        public async Task<Supplier?> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.Suppliers.SingleOrDefaultAsync(s => s.Id == id, cancellationToken);
        }

        public async Task UpdateAsync(Supplier supplier, CancellationToken cancellationToken)
        {
            _context.Suppliers.Update(supplier);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
