using Application.Bazaar.BazzarRepositories;
using Domain.Models;
using Domain.StronglyTypes;

namespace Application.Users.Repositroies;

public interface IUserRepository : IRepository<User, UserId>
{
    public Task<User> AddUserIfNotExistAsync(User user, CancellationToken cancellationToken = default);
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
