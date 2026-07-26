using LogixonBackend.API.Models;
using LogixonBackend.Application.Commands.CategoryCommands.CreateCategoryCommands;
using LogixonBackend.Application.Commands.CategoryCommands.DeleteCategoryCommands;
using LogixonBackend.Application.Commands.CategoryCommands.UpdateCategoryCommands;
using LogixonBackend.Application.Queries.CategoryQueries.GetAllCategoryQueries;
using LogixonBackend.Application.Queries.CategoryQueries.GetCategoryByIdQueries;
using LogixonBackend.Application.ViewModels.CategoryViewModels;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LogixonBackend.API.Controllers
{
    [Route("api/category"), ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllCategoryQuery();
            var data = await _mediator.Send(query);
            return Ok(new ApiResponse<List<CategoryViewModelDTO>>
            {
                Status = true,
                Message = null,
                Data = data
            });
        }

        [HttpGet, Route("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var query = new GetCategoryByIdQuery(id);
            var data = await _mediator.Send(query);
            return Ok(new ApiResponse<CategoryViewModelDTO>
            {
                Status = true,
                Message = null,
                Data = data
            });
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateCategoryCommand command)
        {
            await _mediator.Send(command);
            return Ok(new ApiResponse<object>
            {
                Status = true,
                Message = "Categoria criada com sucesso",
                Data = null
            });
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateCategoryCommand command)
        {
            await _mediator.Send(command);
            return Ok(new ApiResponse<object>
            {
                Status = true,
                Message = "Categoria atualizada com sucesso!",
                Data = null
            });
        }

        [HttpDelete, Route("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var command = new DeleteCategoryCommand(id);
            await _mediator.Send(command);
            return Ok(new ApiResponse<object>
            {
                Status = true,
                Message = "Categoria removida com sucesso!",
                Data = null
            });
        }
    }
}
