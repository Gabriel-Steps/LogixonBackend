using LogixonBackend.API.Models;
using LogixonBackend.Application.Commands.StockAlertCommands.CreateStockAlertCommands;
using LogixonBackend.Application.Commands.StockAlertCommands.DeleteStockAlertCommands;
using LogixonBackend.Application.Queries.StockAlertQueries.GetAllStockAlertQueries;
using LogixonBackend.Application.Queries.StockAlertQueries.GetStockAlertByIdQueries;
using LogixonBackend.Application.ViewModels.StockAlertViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LogixonBackend.API.Controllers
{
    [Route("api/stock-alert"), ApiController]
    public class StockAlertController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StockAlertController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var query = new GetAllStockAlertQuery();
            var data = await _mediator.Send(query);

            return Ok(new ApiResponse<List<StockAlertViewModelDTO>>
            {
                Status = true,
                Message = null,
                Data = data
            });
        }

        [HttpGet, Route("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var query = new GetStockAlertByIdQuery(id);
            var data = await _mediator.Send(query);

            return Ok(new ApiResponse<StockAlertViewModelDTO>
            {
                Status = true,
                Message = null,
                Data = data
            });
        }

        [HttpDelete, Route("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var command = new DeleteStockAlertCommand(id);
            await _mediator.Send(command);

            return Ok(new ApiResponse<object>
            {
                Status = true,
                Message = "Alerta removido com sucesso!",
                Data = null
            });
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateStockAlertCommand command)
        {
            await _mediator.Send(command);

            return Ok(new ApiResponse<object>
            {
                Status = true,
                Message = "Um aviso foi criado",
                Data = null
            });
        }
    }
}
