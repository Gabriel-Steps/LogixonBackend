using LogixonBackend.Application.Exceptions.StockAlertExceptions;
using LogixonBackend.Infra.Repositories.StockAlertRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogixonBackend.Application.Commands.StockAlertCommands.DeleteStockAlertCommands
{
    public class DeleteStockAlertCommandHandler : IRequestHandler<DeleteStockAlertCommand, Unit>
    {
        private readonly IStockAlertRepository _repository;

        public DeleteStockAlertCommandHandler(IStockAlertRepository repository)
        {
            _repository = repository;
        }
        public async Task<Unit> Handle(DeleteStockAlertCommand request, CancellationToken cancellationToken)
        {
            var stockAlert = await _repository.GetByIdAsync(request.Id, cancellationToken) ??
                throw new NotFoundStockAlertByIdException(request.Id);

            await _repository.DeleteAsync(stockAlert, cancellationToken);

            return Unit.Value;
        }
    }
}
