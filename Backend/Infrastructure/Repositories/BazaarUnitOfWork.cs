using Application.Bazaar.BazzarRepositories;
using Infrastructure.Data.ApplicaionDbContetxt;

namespace Infrastructure.Repositories;

public class BazaarUnitOfWork(AppDbContext appDbContext) : IBazaarUnitOfWork
{
    private readonly IBannerRepository _BannerRepository = new BannerRepository(appDbContext);
    private readonly ICategoryRepository _CategoryRepository = new CategoryRepository(appDbContext);

    public IBannerRepository BannerRepository => _BannerRepository;
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
