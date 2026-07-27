using LogixonBackend.Application.ViewModels.StockAlertViewModels;
using LogixonBackend.Infra.Repositories.StockAlertRepositories;
using MediatR;

namespace LogixonBackend.Application.Queries.StockAlertQueries.GetAllStockAlertQueries
{
    public class GetAllStockAlertQueryHandler : IRequestHandler<GetAllStockAlertQuery, List<StockAlertViewModelDTO>>
    {
        private readonly IStockAlertRepository _repository;

        public GetAllStockAlertQueryHandler(IStockAlertRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<StockAlertViewModelDTO>> Handle(GetAllStockAlertQuery request, CancellationToken cancellationToken)
        {
            var stockAlerts = await _repository.GetAllAsync(cancellationToken);

            return stockAlerts
                .Select(sa => new StockAlertViewModelDTO()
                {
                    AlertType = sa.AlertType,
                    AlertDate = sa.AlertDate,
                    ProductId = sa.ProductId
                }).ToList();
        }
    }
}
