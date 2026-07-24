using LogixonBackend.API.Models;
using LogixonBackend.Application.Commands.AuthCommands.RegisterAuthUserCommands;
using LogixonBackend.Application.Queries.AuthQueries.LoginAuthUserQueries;
using LogixonBackend.Application.ViewModels.AuthViewModels;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LogixonBackend.API.Controllers
{
    [Route("api/auth"), ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost, Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterAuthUserCommand command)
        {
            var data = await _mediator.Send(command);
            return Ok(new ApiResponse<AuthViewModelDTO>
            {
                Status = true,
                Message = "Usuário cadastrado com sucesso!",
                Data = data
            });
        }

        [HttpPost, Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginAuthUserQuery query)
        {
            var data = await _mediator.Send(query);
            return Ok(new ApiResponse<AuthViewModelDTO>
            {
                Status = true,
                Message = "Login realizado com sucesso!",
                Data = data
            });
        }
    }
}
