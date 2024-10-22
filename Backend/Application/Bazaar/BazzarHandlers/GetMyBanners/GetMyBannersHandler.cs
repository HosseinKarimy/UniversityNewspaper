using Application.Bazaar.BazzarRepositories;
using Application.Bazaar.DTO;
using Domain.Models;
using Domain.StronglyTypes;
using Helper.CQRS;

namespace Application.Bazaar.BazzarHandlers.GetMyBanners;

public class GetMyBannersHandler(IBannerRepository bannerRepository) : IQueryHandler<GetMyBannersQuery, GetMyBannersResult>
{
    public async Task<GetMyBannersResult> Handle(GetMyBannersQuery request, CancellationToken cancellationToken)
    {
        List<GoodsBanner> banners = await bannerRepository.GetUserBannersAsync(
            UserId.Of(request.ContextCarrier.AuthenticatedUserId), cancellationToken);
        List<GetBannerDto> bannerDTOs = banners.Select(banner => GetBannerDto.FromBanner(banner)).ToList();
        return new GetMyBannersResult(bannerDTOs);
    }
}
