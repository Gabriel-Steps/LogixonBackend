using LogixonBackend.Application.Services.CacheServices;
using LogixonBackend.Application.ViewModels.ProductViewModels;
using LogixonBackend.Infra.Repositories.ProductRepositories;
using MediatR;

namespace LogixonBackend.Application.Queries.ProductQueries.GetAllProductQueries
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, List<ProductViewModelDTO>>
    {
        private readonly IProductRepository _productRepository;
        private readonly ICacheService _cacheService;
        public GetAllProductQueryHandler(IProductRepository productRepository, ICacheService cacheService)
        {
            _productRepository = productRepository;
            _cacheService = cacheService;
        }
        public async Task<List<ProductViewModelDTO>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            const string cacheKey = "products:all";

            var cachedProducts = await _cacheService.GetAsync<List<ProductViewModelDTO>>(cacheKey);
            if (cachedProducts != null)
                return cachedProducts;

            var products = await _productRepository.GetAllAsync(cancellationToken);
            var result = products.Select(p => new ProductViewModelDTO
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

            await _cacheService.SetAsync(cacheKey, result, TimeSpan.FromHours(1));

            return result;
        }
    }
}
