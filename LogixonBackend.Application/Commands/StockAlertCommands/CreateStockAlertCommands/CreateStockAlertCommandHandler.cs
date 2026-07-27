using LogixonBackend.Domain.Entities;
using LogixonBackend.Infra.Repositories.StockAlertRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogixonBackend.Application.Commands.StockAlertCommands.CreateStockAlertCommands
{
    public class CreateStockAlertCommandHandler : IRequestHandler<CreateStockAlertCommand, Unit>
    {
        private readonly IStockAlertRepository _repository;

        public CreateStockAlertCommandHandler(IStockAlertRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CreateStockAlertCommand request, CancellationToken cancellationToken)
        {
            var stockAlert = new StockAlert()
            {
                AlertDate = DateTime.UtcNow,
                AlertType = request.AlertType,
                ProductId = request.ProductId
            };

            await _repository.CreateAsync(stockAlert, cancellationToken);

            return Unit.Value;
        }
    }
}
