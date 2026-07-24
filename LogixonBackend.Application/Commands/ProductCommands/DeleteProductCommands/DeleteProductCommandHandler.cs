using LogixonBackend.Application.Exceptions.ProductExceptions;
using LogixonBackend.Infra.Repositories.ProductRepositories;
using MediatR;

namespace LogixonBackend.Application.Commands.ProductCommands.DeleteProductCommands
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Unit>
    {
        private readonly IProductRepository _productRepository;
        public DeleteProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id, cancellationToken) ??
                throw new NotFoundProductByIdException(request.Id);
            
            await _productRepository.DeleteAsync(product, cancellationToken);
            return Unit.Value;
        }
    }
}
