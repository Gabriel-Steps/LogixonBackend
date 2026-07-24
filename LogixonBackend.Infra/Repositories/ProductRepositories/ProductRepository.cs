using LogixonBackend.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LogixonBackend.Infra.Repositories.ProductRepositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProjectLogixonDbContext _context;

        public ProductRepository(ProjectLogixonDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Product product, CancellationToken cancellationToken)
        {
            await _context.Products.AddAsync(product, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(Product product, CancellationToken cancellationToken)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<Product>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.Products.AsNoTracking().ToListAsync(cancellationToken);
        }

        public async Task<List<Product>> GetByCategoryIdAsync(int categoryId, CancellationToken cancellationToken)
        {
            return await _context.Products
                .Where(p => p.CategoryId == categoryId)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        public async Task<Product?> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
        }

        public async Task<List<Product>> GetByLowStock(CancellationToken cancellationToken)
        {
            return await _context.Products
                .Where(p => p.QuantityInStock < p.MinimumStock)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        public async Task UpdateAsync(Product product, CancellationToken cancellationToken)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
