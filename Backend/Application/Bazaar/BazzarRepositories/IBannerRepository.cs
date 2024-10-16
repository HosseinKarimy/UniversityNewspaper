using Domain.Models;
using Domain.StronglyTypes;

namespace Application.Bazaar.BazzarRepositories;

public interface IBannerRepository
{
    public Task<Banner> AddBannerAsync(Banner banner, CancellationToken cancellationToken = default);
    public Task<List<Banner>> GetAllBannersAsync(CancellationToken cancellationToken = default);
    public Task<bool> UpdateBannerAsync(Banner banner, CancellationToken cancellationToken = default);
    public Task<Banner?> GetBannersByIdAsync(BannerId bannerId,CancellationToken cancellationToken = default);
}
