namespace Application.Bazaar.BazzarRepositories;

public interface IBazaarUnitOfWork : IDisposable
{
    public IGoodBannerRepository GoodBannerRepository { get; }
    public IServiceBannerRepository ServiceBannerRepository { get; }
    public ICategoryRepository CategoryRepository { get; }
    public Task<int> SaveChangesAsync();
}
