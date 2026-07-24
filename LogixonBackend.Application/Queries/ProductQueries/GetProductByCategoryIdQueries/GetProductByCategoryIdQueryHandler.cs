using LogixonBackend.Application.ViewModels.ProductViewModels;
using LogixonBackend.Infra.Repositories.ProductRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogixonBackend.Application.Queries.ProductQueries.GetProductByCategoryIdQueries
{
    public class GetProductByCategoryIdQueryHandler : IRequestHandler<GetProductByCategoryIdQuery, List<ProductViewModelDTO>>
    {
        private readonly IProductRepository _productRepository;

        public GetProductByCategoryIdQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<ProductViewModelDTO>> Handle(GetProductByCategoryIdQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetByCategoryIdAsync(request.Id, cancellationToken);
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
