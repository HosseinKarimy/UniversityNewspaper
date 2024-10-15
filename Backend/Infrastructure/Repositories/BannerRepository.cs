using Application.Bazaar.BazzarRepositories;
using Domain.Models;
using Infrastructure.Data.ApplicaionDbContetxt;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class BannerRepository : IBannerRepository
{
    private readonly AppDbContext dbContext;

    public BannerRepository(AppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    public async Task<Banner> AddBannerAsync(Banner banner, CancellationToken cancellationToken)
    {
        await dbContext.Banners.AddAsync(banner, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
        return banner;
    }

    public async Task<List<Banner>> GetBannerAsync(CancellationToken cancellationToken = default)
    {
        var banners = await dbContext.Banners.Include(p=>p.Owner).Include(p => p.Category).ToListAsync(cancellationToken);
        return banners;
    }
}
