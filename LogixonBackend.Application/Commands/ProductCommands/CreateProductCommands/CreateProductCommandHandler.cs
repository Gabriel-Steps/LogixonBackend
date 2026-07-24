using LogixonBackend.Domain.Entities;
using LogixonBackend.Infra.Repositories.ProductRepositories;
using MediatR;

namespace LogixonBackend.Application.Commands.ProductCommands.CreateProductCommands
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Unit>
    {
        private readonly IProductRepository _productRepository;
        public CreateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Unit> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Name = request.Name,
                SKU = request.SKU,
                Description = request.Description,
                Price = request.Price,
                QuantityInStock = request.QuantityInStock,
                MinimumStock = request.MinimumStock,
                MaximumStock = request.MaximumStock,
                CategoryId = request.CategoryId,
                SupplierId = request.SupplierId
            };
            await _productRepository.CreateAsync(product, cancellationToken);
            return Unit.Value;
        }
    }
}
