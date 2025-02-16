using Application.Bazaar.BazzarRepositories;
using Infrastructure.Data.ApplicaionDbContetxt;

namespace Infrastructure.Repositories;

public class BazaarUnitOfWork(AppDbContext appDbContext) : IBazaarUnitOfWork
{
    private readonly IGoodBannerRepository _goodBannerRepository = null;
    private readonly IServiceBannerRepository _serviceBannerRepository = null;
    private readonly ICategoryRepository _CategoryRepository = new CategoryRepository(appDbContext);

    public IGoodBannerRepository GoodBannerRepository => _goodBannerRepository; 

    public IServiceBannerRepository ServiceBannerRepository => _serviceBannerRepository;

    public ICategoryRepository CategoryRepository => _CategoryRepository;

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
        return await appDbContext.SaveChangesAsync(cancellationToken);
    }

    public void Dispose()
    {
        appDbContext.Dispose();
    }
}
