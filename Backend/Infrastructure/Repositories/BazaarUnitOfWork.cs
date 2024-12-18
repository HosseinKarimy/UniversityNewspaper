using Application.Bazaar.BazzarRepositories;
using Infrastructure.Data.ApplicaionDbContetxt;

namespace Infrastructure.Repositories;

public class BazaarUnitOfWork(AppDbContext appDbContext) : IBazaarUnitOfWork
{
    private readonly IGoodBannerRepository _goodBannerRepository = new GoodBannerRepository(appDbContext);

    public IGoodBannerRepository GoodBannerRepository { get => _goodBannerRepository; }

    public async Task<int> SaveChangesAsync()
    {
        return await appDbContext.SaveChangesAsync();
    }

    public void Dispose()
    {
        appDbContext.Dispose();
    }
}
