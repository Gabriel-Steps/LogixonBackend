using LogixonBackend.Application.ViewModels.StockMovementsModels;
using LogixonBackend.Infra.Repositories.StockMovementsRepositories;
using MediatR;

namespace LogixonBackend.Application.Queries.StockMovementQueries.GetStockMovementByUserIdQueries
{
    public class GetStockMovementByUserIdQueryHandler : IRequestHandler<GetStockMovementByUserIdQuery, List<StockMovementViewModelDTO>>
    {
        private readonly IStockMovementsRepository _repository;

        public GetStockMovementByUserIdQueryHandler(IStockMovementsRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<StockMovementViewModelDTO>> Handle(GetStockMovementByUserIdQuery request, CancellationToken cancellationToken)
        {
            var stockMovements = await _repository.GetByUserId(request.Id, cancellationToken);

            return stockMovements
                .Select(sm => new StockMovementViewModelDTO()
                {
                    Id = sm.Id,
                    Type = sm.Type,
                    Quantity = sm.Quantity,
                    Reason = sm.Reason,
                    Notes = sm.Notes,
                    ProductId = sm.ProductId,
                    UserId = sm.UserId
                }).ToList();
        }
    }
}
