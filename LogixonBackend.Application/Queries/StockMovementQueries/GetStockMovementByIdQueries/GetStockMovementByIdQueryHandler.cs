using LogixonBackend.Application.Exceptions.StockMovementsExceptions;
using LogixonBackend.Application.ViewModels.StockMovementsModels;
using LogixonBackend.Infra.Repositories.StockMovementsRepositories;
using MediatR;

namespace LogixonBackend.Application.Queries.StockMovementQueries.GetStockMovementByIdQueries
{
    public class GetStockMovementByIdQueryHandler : IRequestHandler<GetStockMovementByIdQuery, StockMovementViewModelDTO>
    {
        private readonly IStockMovementsRepository _repository;

        public GetStockMovementByIdQueryHandler(IStockMovementsRepository repository)
        {
            _repository = repository;
        }

        public async Task<StockMovementViewModelDTO> Handle(GetStockMovementByIdQuery request, CancellationToken cancellationToken)
        {
            var stockMovement = await _repository.GetByIdAsync(request.Id, cancellationToken) ??
                throw new NotFoundStockMovementByIdException(request.Id);

            return new StockMovementViewModelDTO()
            {
                Id = stockMovement.Id,
                Type = stockMovement.Type,
                Quantity = stockMovement.Quantity,
                Reason = stockMovement.Reason,
                Notes = stockMovement.Notes,
                ProductId = stockMovement.ProductId,
                UserId = stockMovement.UserId
            };
        }
    }
}
