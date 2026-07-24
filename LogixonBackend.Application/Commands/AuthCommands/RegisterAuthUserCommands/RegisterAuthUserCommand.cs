using LogixonBackend.Application.ViewModels.AuthViewModels;
using MediatR;

namespace LogixonBackend.Application.Commands.AuthCommands.RegisterAuthUserCommands
{
    public class RegisterAuthUserCommand : IRequest<AuthViewModelDTO>
    {
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
