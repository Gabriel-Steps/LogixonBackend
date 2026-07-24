using LogixonBackend.API.Models;
using LogixonBackend.Application.Commands.ProductCommands.CreateProductCommands;
using LogixonBackend.Application.Commands.ProductCommands.DeleteProductCommands;
using LogixonBackend.Application.Commands.ProductCommands.UpdateProductCommands;
using LogixonBackend.Application.Queries.ProductQueries.GetAllProductQueries;
using LogixonBackend.Application.Queries.ProductQueries.GetProductByCategoryIdQueries;
using LogixonBackend.Application.Queries.ProductQueries.GetProductByIdQueries;
using LogixonBackend.Application.Queries.ProductQueries.GetProductByLowStockQueries;
using LogixonBackend.Application.ViewModels.ProductViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LogixonBackend.API.Controllers
{
    [Route("api/product"), ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var query = new GetAllProductQuery();
            var data = await _mediator.Send(query);
            return Ok(new ApiResponse<List<ProductViewModelDTO>>
            {
                Status = true,
                Message = null,
                Data = data
            });
        }

        [HttpGet, Route("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var query = new GetProductByIdQuery(id);
            var data = await _mediator.Send(query);
            return Ok(new ApiResponse<ProductViewModelDTO>
            {
                Status = true,
                Message = null,
                Data = data
            });
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateProductCommand command)
        {
            await _mediator.Send(command);
            return Ok(new ApiResponse<object>
            {
                Status = true,
                Message = "Produto criado com sucesso!",
                Data = null
            });
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateProductCommand command)
        {
            await _mediator.Send(command);
            return Ok(new ApiResponse<object>
            {
                Status = true,
                Message = "Produto atualizado com sucesso!",
                Data = null
            });
        }

        [HttpDelete, Route("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var command = new DeleteProductCommand(id);
            await _mediator.Send(command);
            return Ok(new ApiResponse<object>
            {
                Status = true,
                Message = "Produto deletado com sucesso!",
                Data = null
            });
        }

        [HttpGet, Route("category/{categoryId}")]
        public async Task<IActionResult> GetByCategoryIdAsync(int categoryId)
        {
            var query = new GetProductByCategoryIdQuery(categoryId);
            var data = await _mediator.Send(query);
            return Ok(new ApiResponse<List<ProductViewModelDTO>>
            {
                Status = true,
                Message = null,
                Data = data
            });
        }

        [HttpGet, Route("low-stock")]
        public async Task<IActionResult> GetByLowStockAsync()
        {
            var query = new GetProductByLowStockQuery();
            var data = await _mediator.Send(query);
            return Ok(new ApiResponse<List<ProductViewModelDTO>>
            {
                Status = true,
                Message = null,
                Data = data
            });
        }
    }
}
