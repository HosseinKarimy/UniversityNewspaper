using Application.Bazaar.BazzarRepositories;
using Domain.Models;
using Domain.StronglyTypes;
using Infrastructure.Data.ApplicaionDbContetxt;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.BazaarRepositiories;

public class BannerRepository(AppDbContext dbContext) : Repository<Banner, BannerId>(dbContext.Banners), IBannerRepository
{
    public async Task<List<Banner>> GetBannersByUserID(UserId userId, CancellationToken cancellationToken)
    {
        return await dbContext.Banners.Where(banner => banner.OwnerId == userId).ToListAsync(cancellationToken);
    }
}
