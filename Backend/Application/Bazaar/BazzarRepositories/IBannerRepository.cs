using Application.Bazaar.DTO;
using Domain.Models;
using Domain.StronglyTypes;

namespace Application.Bazaar.BazzarRepositories;

public interface IBannerRepository : IRepository<Banner, BannerId>
{
    public Task<List<Banner>> GetBannersCreatedByUser(UserId userId, CancellationToken cancellationToken = default);
    public Task<List<Banner>> GetFilteredBannres(BannerSearchFilter Filters, CancellationToken cancellationToken = default);
}
