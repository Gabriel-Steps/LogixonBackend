using LogixonBackend.Application.ViewModels.AuthViewModels;
using MediatR;

namespace LogixonBackend.Application.Queries.AuthQueries.LoginAuthUserQueries
{
    public class LoginAuthUserQuery : IRequest<AuthViewModelDTO>
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
