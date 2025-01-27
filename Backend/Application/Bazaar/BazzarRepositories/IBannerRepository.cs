using Domain.Models;
using Domain.StronglyTypes;

namespace Application.Bazaar.BazzarRepositories;

public interface IBannerRepository<T> : IRepository<T, Guid> where T : class
{
    Task<List<T>> GetBannersByUserID(UserId userId, CancellationToken cancellationToken = default);
}
