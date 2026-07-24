using LogixonBackend.Application.ViewModels.ProductViewModels;
using LogixonBackend.Infra.Repositories.ProductRepositories;
using MediatR;

namespace LogixonBackend.Application.Queries.ProductQueries.GetProductByLowStockQueries
{
    public class GetProductByLowStockQueryHandler : IRequestHandler<GetProductByLowStockQuery, List<ProductViewModelDTO>>
    {
        private readonly IProductRepository _repository;
        
        public GetProductByLowStockQueryHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ProductViewModelDTO>> Handle(GetProductByLowStockQuery request, CancellationToken cancellationToken)
        {
            var products = await _repository.GetByLowStock(cancellationToken);
            return products.Select(p => new ProductViewModelDTO
            {
                Id = p.Id,
                Name = p.Name,
                SKU = p.SKU,
                Description = p.Description,
                Price = p.Price,
                QuantityInStock = p.QuantityInStock,
                MinimumStock = p.MinimumStock,
                MaximumStock = p.MaximumStock,
                IsActive = p.IsActive,
                CreatedAt = p.CreatedAt,
                CategoryId = p.CategoryId,
                SupplierId = p.SupplierId
            }).ToList();
        }
    }
}
