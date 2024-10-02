using Domain.Models;

namespace Application.BazaarRepositories;

public interface IBannerRepository
{
    public Task<Banner> AddBannerAsync(Banner banner , CancellationToken cancellationToken);

}
