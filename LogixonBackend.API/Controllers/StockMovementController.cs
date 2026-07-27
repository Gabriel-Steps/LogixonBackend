using LogixonBackend.API.Models;
using LogixonBackend.Application.Commands.StockMovementCommands.CreateStockMovementCommands;
using LogixonBackend.Application.Queries.StockMovementQueries.GetAllStockMovementQueries;
using LogixonBackend.Application.Queries.StockMovementQueries.GetStockMovementByIdQueries;
using LogixonBackend.Application.Queries.StockMovementQueries.GetStockMovementByProductIdQueries;
using LogixonBackend.Application.Queries.StockMovementQueries.GetStockMovementByUserIdQueries;
using LogixonBackend.Application.ViewModels.StockMovementsModels;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LogixonBackend.API.Controllers
{
    [Route("api/stock-movement"), ApiController]
    public class StockMovementController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StockMovementController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var query = new GetAllStockMovementQuery();
            var data = await _mediator.Send(query);

            return Ok(new ApiResponse<List<StockMovementViewModelDTO>>
            {
                Status = true,
                Message = null,
                Data = data
            });
        }

        [HttpGet, Route("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var query = new GetStockMovementByIdQuery(id);
            var data = await _mediator.Send(query);

            return Ok(new ApiResponse<StockMovementViewModelDTO>
            {
                Status = true,
                Message = null,
                Data = data
            });
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateStockMovementCommand command)
        {
            await _mediator.Send(command);

            return Ok(new ApiResponse<object>
            {
                Status = true,
                Message = null,
                Data = null
            });
        }

        [HttpGet, Route("product/{id}")]
        public async Task<IActionResult> GetByproductId(int id)
        {
            var query = new GetStockMovementByProductIdQuery(id);
            var data = await _mediator.Send(query);

            return Ok(new ApiResponse<List<StockMovementViewModelDTO>>
            {
                Status = true,
                Message = null,
                Data = data
            });
        }

        [HttpGet, Route("user/{id}")]
        public async Task<IActionResult> GetByUserId(int id)
        {
            var query = new GetStockMovementByUserIdQuery(id);
            var data = await _mediator.Send(query);

            return Ok(new ApiResponse<List<StockMovementViewModelDTO>>
            {
                Status = true,
                Message = null,
                Data = data
            });
        }
    }
}
