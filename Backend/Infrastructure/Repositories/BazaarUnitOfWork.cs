using Application.Bazaar.BazzarRepositories;
using Infrastructure.Data.ApplicaionDbContetxt;

namespace Infrastructure.Repositories;

public class BazaarUnitOfWork(AppDbContext appDbContext) : IBazaarUnitOfWork
{
    private readonly IGoodBannerRepository _goodBannerRepository = new GoodBannerRepository(appDbContext);
    private readonly IServiceBannerRepository _serviceBannerRepository = new ServiceBannerRepository(appDbContext);

    public IGoodBannerRepository GoodBannerRepository => _goodBannerRepository; 

    public IServiceBannerRepository ServiceBannerRepository => _serviceBannerRepository;

    public async Task<int> SaveChangesAsync()
    {
        return await appDbContext.SaveChangesAsync();
    }

    public void Dispose()
    {
        appDbContext.Dispose();
    }
}
