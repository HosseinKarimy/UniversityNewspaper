using Application.Bazaar.BazzarRepositories;
using Application.Bazaar.DTO;
using Domain.Models;
using Domain.StronglyTypes;
using Helper.CQRS;

namespace Application.Bazaar.BazzarHandlers.GetMyBanners;

public class GetMyBannersHandler(IBazaarUnitOfWork bannerRepository) : IQueryHandler<GetMyBannersQuery, GetMyBannersResult>
{
    public async Task<GetMyBannersResult> Handle(GetMyBannersQuery request, CancellationToken cancellationToken)
    {
        UserId userId = request.ContextCarrier.AuthenticatedUser.UserId;
        List<GoodBanner> goodBanners = await bannerRepository.GoodBannerRepository.GetBannersByUserID(userId
           , cancellationToken);
        List<ServiceBanner> serviceBanners = await bannerRepository.ServiceBannerRepository.GetBannersByUserID(
            userId, cancellationToken);
        List<GetGoodBannerDto> goodBannerDto = goodBanners.Select(banner => GetGoodBannerDto.FromBanner(banner)).ToList();
        List<GetServiceBannerDto> serviceBannerDto = serviceBanners.Select(banner => GetServiceBannerDto.FromBanner(banner)).ToList();
        return new GetMyBannersResult(goodBannerDto, serviceBannerDto);
     
    }
}
