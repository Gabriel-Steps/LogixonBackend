using LogixonBackend.Application.ViewModels.ProductViewModels;
using LogixonBackend.Infra.Repositories.ProductRepositories;
using MediatR;

namespace LogixonBackend.Application.Queries.ProductQueries.GetAllProductQueries
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, List<ProductViewModelDTO>>
    {
        private readonly IProductRepository _productRepository;
        public GetAllProductQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<List<ProductViewModelDTO>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetAllAsync(cancellationToken);
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
