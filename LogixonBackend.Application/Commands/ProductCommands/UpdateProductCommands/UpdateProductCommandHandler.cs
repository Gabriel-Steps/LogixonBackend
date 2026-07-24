using LogixonBackend.Application.Exceptions.ProductExceptions;
using LogixonBackend.Infra.Repositories.ProductRepositories;
using MediatR;

namespace LogixonBackend.Application.Commands.ProductCommands.UpdateProductCommands
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Unit>
    {
        private readonly IProductRepository _repository;

        public UpdateProductCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetByIdAsync(request.Id, cancellationToken) ??
                throw new NotFoundProductByIdException(request.Id);

            product.Name = request.Name;
            product.SKU = request.SKU;
            product.Description = request.Description;
            product.Price = request.Price;
            product.QuantityInStock = request.QuantityInStock;
            product.MinimumStock = request.MinimumStock;
            product.MaximumStock = request.MaximumStock;
            product.CategoryId = request.CategoryId;

            await _repository.UpdateAsync(product, cancellationToken);
            return Unit.Value;
        }
    }
}
