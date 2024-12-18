namespace Application.Bazaar.BazzarRepositories;

public interface IBazaarUnitOfWork : IDisposable
{
    public IGoodBannerRepository GoodBannerRepository { get; }
    public Task<int> SaveChangesAsync();
}
