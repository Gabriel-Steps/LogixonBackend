using LogixonBackend.Application.ViewModels.StockMovementsModels;
using LogixonBackend.Infra.Repositories.StockMovementsRepositories;
using MediatR;

namespace LogixonBackend.Application.Queries.StockMovementQueries.GetAllStockMovementQueries
{
    public class GetAllStockMovementQueryHandler : IRequestHandler<GetAllStockMovementQuery, List<StockMovementViewModelDTO>>
    {
        private readonly IStockMovementsRepository _repository;

        public GetAllStockMovementQueryHandler(IStockMovementsRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<StockMovementViewModelDTO>> Handle(GetAllStockMovementQuery request, CancellationToken cancellationToken)
        {
            var stockMovements = await _repository.GetAllAsync(cancellationToken);

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
