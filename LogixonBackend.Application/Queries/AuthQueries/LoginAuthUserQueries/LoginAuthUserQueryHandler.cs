using LogixonBackend.Application.Exceptions.AuthExceptions;
using LogixonBackend.Application.Services;
using LogixonBackend.Application.ViewModels.AuthViewModels;
using LogixonBackend.Infra.Repositories.AuthRepositories;
using MediatR;

namespace LogixonBackend.Application.Queries.AuthQueries.LoginAuthUserQueries
{
    public class LoginAuthUserQueryHandler : IRequestHandler<LoginAuthUserQuery, AuthViewModelDTO>
    {
        private readonly IAuthRepository _authRepository;
        private readonly PasswordService _passwordService;
        private readonly TokenService _tokenService;

        public LoginAuthUserQueryHandler(IAuthRepository authRepository, PasswordService passwordService, TokenService tokenService)
        {
            _authRepository = authRepository;
            _passwordService = passwordService;
            _tokenService = tokenService;
        }

        public async Task<AuthViewModelDTO> Handle(LoginAuthUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _authRepository.GetUserByEmailAsync(request.Email, cancellationToken)
                ?? throw new NotFoundUserByEmailException(request.Email);

            if(!_passwordService.VerifyPassword(user, request.Password, user.PasswordHash))
                throw new AccessInvalidAuthUserException(request.Email);

            return new AuthViewModelDTO()
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                Token = _tokenService.GenerateToken(user),
                CreatedAt = user.CreatedAt
            };
        }
    }
}
