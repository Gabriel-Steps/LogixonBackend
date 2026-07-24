using LogixonBackend.Domain.Entities;

namespace LogixonBackend.Infra.Repositories.AuthRepositories
{
    public interface IAuthRepository
    {
        public Task CreateUserAsync(User user, CancellationToken cancellationToken);
        public Task<User?> GetUserByEmailAsync(string email, CancellationToken cancellationToken);
    }
}
