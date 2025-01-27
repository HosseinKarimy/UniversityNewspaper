using Application.Bazaar.BazzarRepositories;
using Domain.Models;
using Domain.StronglyTypes;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public abstract class BannerRepository<T>(DbSet<T> set) : Repository<T, Guid>(set), IBannerRepository<T> where T : Banner
{
    public async Task<List<T>> GetBannersByUserID(UserId userId, CancellationToken cancellationToken = default)
    {
        return await set.Where(banner => banner.OwnerId == userId).ToListAsync(cancellationToken);
    }
}
