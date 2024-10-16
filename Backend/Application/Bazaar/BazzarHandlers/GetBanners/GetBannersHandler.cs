using Application.Bazaar.BazzarRepositories;
using Application.Bazaar.DTO;
using Domain.Models;
using Helper.CQRS;

namespace Application.Bazaar.BazzarHandlers.GetBanners;

public class GetBannersHandler(IBannerRepository bannerRepository) : IQueryHandler<GetBannersQuery, GetBannerResult>
{
    public async Task<GetBannerResult> Handle(GetBannersQuery request, CancellationToken cancellationToken)
    {
        List<Banner> banners = await bannerRepository.GetAllBannersAsync(cancellationToken);
        List<GetBannerDto> bannerDTOs = banners.Select(banner => GetBannerDto.FromBanner(banner)).ToList();
        return new GetBannerResult(bannerDTOs);
    }
}
