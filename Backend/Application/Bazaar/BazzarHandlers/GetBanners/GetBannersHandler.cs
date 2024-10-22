using Application.Bazaar.BazzarRepositories;
using Application.Bazaar.DTO;
using Domain.Models;
using Helper.CQRS;

namespace Application.Bazaar.BazzarHandlers.GetBanners;

public class GetBannersHandler(IBannerRepository bannerRepository) : IQueryHandler<GetBannersQuery, GetBannersResult>
{
    public async Task<GetBannersResult> Handle(GetBannersQuery request, CancellationToken cancellationToken)
    {
        List<GoodsBanner> banners = await bannerRepository.GetAllBannersAsync(cancellationToken);
        List<GetBannerDto> bannerDTOs = banners.Select(banner => GetBannerDto.FromBanner(banner)).ToList();
        return new GetBannersResult(bannerDTOs);
    }
}
