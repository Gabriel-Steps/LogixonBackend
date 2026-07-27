using LogixonBackend.API.Models;
using LogixonBackend.Application.Commands.SupplierCommands.CreateSupplierCommands;
using LogixonBackend.Application.Commands.SupplierCommands.DeleteSupplierCommands;
using LogixonBackend.Application.Commands.SupplierCommands.UpdateSupplierCommands;
using LogixonBackend.Application.Queries.SupplierQueries.GetAllSupplierQueries;
using LogixonBackend.Application.Queries.SupplierQueries.GetSupplierByIdQueries;
using LogixonBackend.Application.ViewModels.SupplierViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LogixonBackend.API.Controllers
{
    [Route("api/supplier"), ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SupplierController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var query = new GetAllSupplierQuery();
            var data = await _mediator.Send(query);
            return Ok(new ApiResponse<List<SupplierViewModelDTO>>
            {
                Status = true,
                Message = null,
                Data = data
            });
        }

        [HttpGet, Route("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var query = new GetSupplierByIdQuery(id);
            var data = await _mediator.Send(query);

            return Ok(new ApiResponse<SupplierViewModelDTO>
            {
                Status = true,
                Message = null,
                Data = data
            });
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateSupplierCommand command)
        {
            await _mediator.Send(command);
            return Ok(new ApiResponse<object>
            {
                Status = true,
                Message = "Fornecedor criado com sucesso!",
                Data = null
            });
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateSupplierCommand command)
        {
            await _mediator.Send(command);
            return Ok(new ApiResponse<object>
            {
                Status = true,
                Message = "Fornecedor atualizado com sucesso!",
                Data = null
            });
        }

        [HttpDelete, Route("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var command = new DeleteSupplierCommand(id);
            await _mediator.Send(command);

            return Ok(new ApiResponse<object>
            {
                Status = true,
                Message = "Fornecedor removido com sucesso!",
                Data = null
            });
        }
    }
}