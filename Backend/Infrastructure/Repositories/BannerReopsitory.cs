using Application.BazaarRepositories;
using Domain.Models;

namespace Infrastructure.Repositories;

public class BannerReopsitory : IBannerRepository
{
    public Task<Banner> AddBannerAsync(Banner banner, CancellationToken cancellationToken)
    {
        FakeDataBase.Banners.Add(banner);
        return Task.FromResult(banner);
    }
}
