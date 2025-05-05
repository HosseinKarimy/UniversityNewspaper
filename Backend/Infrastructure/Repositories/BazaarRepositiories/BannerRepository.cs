using Application.Bazaar.BazzarRepositories;
using Application.Bazaar.DTO;
using Domain.Models;
using Domain.StronglyTypes;
using Infrastructure.Data.ApplicaionDbContetxt;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.BazaarRepositiories;

public class BannerRepository(AppDbContext dbContext) : Repository<Banner, BannerId>(dbContext.Banners), IBannerRepository
{
    public async Task<List<Banner>> GetBannersCreatedByUser(UserId userId, CancellationToken cancellationToken)
    {
        return await dbContext.Banners.Where(banner => banner.OwnerId == userId).ToListAsync(cancellationToken);
    }

    public async Task<List<Banner>> GetFilteredBannres(BannerSearchFilter Filters, CancellationToken cancellationToken = default)
    {
        var query = dbContext.Banners.AsQueryable();

        if (!string.IsNullOrWhiteSpace(Filters.Title))
            query = query.Where(e => e.Title.Contains(Filters.Title));

        if (Filters.CategoryId.HasValue)
            query = query.Where(e => e.CategoryId == CategoryId.Of(Filters.CategoryId.Value));

        return await query
            .OrderByDescending(e => e.CreatedAt)
            .Skip((Filters.Page - 1) * Filters.PageSize)
            .Take(Filters.PageSize)
            .ToListAsync(cancellationToken);
    }
}
