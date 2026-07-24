using LogixonBackend.Application.Services;
using LogixonBackend.Application.ViewModels.AuthViewModels;
using LogixonBackend.Domain.Entities;
using LogixonBackend.Infra.Repositories.AuthRepositories;
using MediatR;

namespace LogixonBackend.Application.Commands.AuthCommands.RegisterAuthUserCommands
{
    public class RegisterAuthUserCommandHandler : IRequestHandler<RegisterAuthUserCommand, AuthViewModelDTO>
    {
        private readonly IAuthRepository _authRepository;
        private readonly PasswordService _passwordService;
        private readonly TokenService _tokenService;

        public RegisterAuthUserCommandHandler(IAuthRepository authRepository, PasswordService passwordService, TokenService tokenService)
        {
            _authRepository = authRepository;
            _passwordService = passwordService;
            _tokenService = tokenService;
        }

        public async Task<AuthViewModelDTO> Handle(RegisterAuthUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User()
            {
                FullName = request.FullName,
                Email = request.Email,
                CreatedAt = DateTime.UtcNow,
                IsActive = true
            };

            user.PasswordHash = _passwordService.HashPassword(user, request.Password);
            await _authRepository.CreateUserAsync(user, cancellationToken);

            return new AuthViewModelDTO()
            {
                Id = user.Id,
                FullName = request.FullName,
                Email = request.Email,
                Token = _tokenService.GenerateToken(user),
                CreatedAt = user.CreatedAt
            };
        }
    }
}
