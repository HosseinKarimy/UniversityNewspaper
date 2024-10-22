using Domain.Models;
using Domain.StronglyTypes;

namespace Application.Bazaar.BazzarRepositories;

public interface IBannerRepository
{
    /// <summary>
    /// Add GoodsBanner For User
    /// </summary>
    /// <param name="banner"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task<GoodsBanner> AddBannerAsync(GoodsBanner banner, CancellationToken cancellationToken = default);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task<List<GoodsBanner>> GetAllBannersAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="banner"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task<bool> UpdateBannerAsync(GoodsBanner banner, CancellationToken cancellationToken = default);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="bannerId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task<GoodsBanner?> GetBannersByIdAsync(BannerId bannerId,CancellationToken cancellationToken = default);

    /// <summary>
    /// Getting a list of banners of a user
    /// </summary>
    /// <param name="userId">The ID of the user whose we want to list banners</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task<List<GoodsBanner>> GetUserBannersAsync(UserId userId,CancellationToken cancellationToken = default);
}
