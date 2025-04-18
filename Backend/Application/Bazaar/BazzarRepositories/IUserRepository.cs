using Domain.Models;
using Domain.StronglyTypes;

namespace Application.Bazaar.BazzarRepositories;

public interface IUserRepository : IRepository<User,UserId>
{
    public Task<User> AddUserIfNotExistAsync(User user, CancellationToken cancellationToken = default);
}
