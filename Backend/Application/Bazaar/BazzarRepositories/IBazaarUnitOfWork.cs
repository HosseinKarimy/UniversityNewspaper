namespace Application.Bazaar.BazzarRepositories;

public interface IBazaarUnitOfWork : IDisposable
{
    public IBannerRepository BannerRepository { get; }
    public ICategoryRepository CategoryRepository { get; }
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
