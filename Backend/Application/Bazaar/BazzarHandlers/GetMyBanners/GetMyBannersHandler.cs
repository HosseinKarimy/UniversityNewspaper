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
        UserId userId = request.ContextCarrier.AuthenticatedUser.Id;
        List<Banner> banners = await bannerRepository.BannerRepository.GetBannersByUserID(userId, cancellationToken);
        var goods = banners.OfType<GoodBanner>().Select(banner => GoodBannerDto.FromBanner(banner)).ToList();
        var services = banners.OfType<ServiceBanner>().Select(banner => ServiceBannerDto.FromBanner(banner)).ToList();

        return new GetMyBannersResult(goods, services);
    }
}
