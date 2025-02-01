using Application.Bazaar.BazzarRepositories;
using Infrastructure.Data.ApplicaionDbContetxt;

namespace Infrastructure.Repositories;

public class BazaarUnitOfWork(AppDbContext appDbContext) : IBazaarUnitOfWork
{
    private readonly IGoodBannerRepository _goodBannerRepository = new GoodBannerRepository(appDbContext);
    private readonly IServiceBannerRepository _serviceBannerRepository = new ServiceBannerRepository(appDbContext);
    private readonly ICategoryRepository _CategoryRepository = new CategoryRepository(appDbContext);

    public IGoodBannerRepository GoodBannerRepository => _goodBannerRepository; 

    public IServiceBannerRepository ServiceBannerRepository => _serviceBannerRepository;

    public IEventBannerRepository EventBannerRepository => throw new NotImplementedException();

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
