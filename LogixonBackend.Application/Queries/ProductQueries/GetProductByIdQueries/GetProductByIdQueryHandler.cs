using LogixonBackend.Application.Exceptions.ProductExceptions;
using LogixonBackend.Application.ViewModels.ProductViewModels;
using LogixonBackend.Infra.Repositories.ProductRepositories;
using MediatR;

namespace LogixonBackend.Application.Queries.ProductQueries.GetProductByIdQueries
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductViewModelDTO>
    {
        private readonly IProductRepository _repository;

        public GetProductByIdQueryHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<ProductViewModelDTO> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetByIdAsync(request.Id, cancellationToken) ?? 
                throw new NotFoundProductByIdException(request.Id);

            return new ProductViewModelDTO
            {
                Id = product.Id,
                Name = product.Name,
                SKU = product.SKU,
                Description = product.Description,
                Price = product.Price,
                QuantityInStock = product.QuantityInStock,
                MinimumStock = product.MinimumStock,
                MaximumStock = product.MaximumStock,
                IsActive = product.IsActive,
                CreatedAt = product.CreatedAt,
                CategoryId = product.CategoryId,
                SupplierId = product.SupplierId
            };
        }
    }
}
