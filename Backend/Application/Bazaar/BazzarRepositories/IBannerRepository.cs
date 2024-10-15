using Domain.Models;

namespace Application.Bazaar.BazzarRepositories;

public interface IBannerRepository
{
    public Task<Banner> AddBannerAsync(Banner banner, CancellationToken cancellationToken = default);
    public Task<List<Banner>> GetBannerAsync(CancellationToken cancellationToken = default);
}
