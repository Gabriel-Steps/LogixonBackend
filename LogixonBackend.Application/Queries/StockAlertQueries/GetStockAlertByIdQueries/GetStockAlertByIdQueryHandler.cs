using LogixonBackend.Application.Exceptions.StockAlertExceptions;
using LogixonBackend.Application.ViewModels.StockAlertViewModels;
using LogixonBackend.Infra.Repositories.StockAlertRepositories;
using MediatR;

namespace LogixonBackend.Application.Queries.StockAlertQueries.GetStockAlertByIdQueries
{
    public class GetStockAlertByIdQueryHandler : IRequestHandler<GetStockAlertByIdQuery, StockAlertViewModelDTO>
    {
        private readonly IStockAlertRepository _repository;

        public GetStockAlertByIdQueryHandler(IStockAlertRepository repository)
        {
            _repository = repository;
        }

        public async Task<StockAlertViewModelDTO> Handle(GetStockAlertByIdQuery request, CancellationToken cancellationToken)
        {
            var stockAlert = await _repository.GetByIdAsync(request.Id, cancellationToken) ??
                throw new NotFoundStockAlertByIdException(request.Id);

            return new StockAlertViewModelDTO()
            {
                AlertDate = stockAlert.AlertDate,
                AlertType = stockAlert.AlertType,
                ProductId = stockAlert.ProductId
            };
        }
    }
}
