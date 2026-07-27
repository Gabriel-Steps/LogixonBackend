using LogixonBackend.Domain.Entities;
using LogixonBackend.Infra.Repositories.StockMovementsRepositories;
using MediatR;

namespace LogixonBackend.Application.Commands.StockMovementCommands.CreateStockMovementCommands
{
    public class CreateStockMovementCommandHandler : IRequestHandler<CreateStockMovementCommand, Unit>
    {
        private readonly IStockMovementsRepository _repository;

        public CreateStockMovementCommandHandler(IStockMovementsRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CreateStockMovementCommand request, CancellationToken cancellationToken)
        {
            var stockMovement = new StockMovement()
            {
                Type = request.Type,
                Quantity = request.Quantity,
                Reason = request.Reason,
                Notes = request.Notes,
                CreatedAt = DateTime.UtcNow,
                ProductId = request.ProductId,
                UserId = request.UserId
            };

            await _repository.CreateAsync(stockMovement, cancellationToken);

            return Unit.Value;
        }
    }
}
