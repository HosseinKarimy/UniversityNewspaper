using Domain.Models;

namespace Application.Bazaar.BazzarRepositories;

public interface IUserRepository
{
    public Task<User> AddUserIfNotExistAsync(User user, CancellationToken cancellationToken = default);
}
