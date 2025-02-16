using Application.Bazaar.BazzarRepositories;
using Application.Bazaar.DTO;
using Domain.Models;
using Helper.CQRS;

namespace Application.Bazaar.BazzarHandlers.GetBanners;

public class GetBannersHandler(IBazaarUnitOfWork bazaarUnitOfWork) : IQueryHandler<GetBannersQuery, GetBannersResult>
{
    public async Task<GetBannersResult> Handle(GetBannersQuery request, CancellationToken cancellationToken)
    {
        var banners = await bazaarUnitOfWork.BannerRepository.GetAllAsync(cancellationToken);
        var goods = banners.OfType<GoodBanner>().Select(banner => GoodBannerDto.FromBanner(banner)).ToList();
        var services = banners.OfType<ServiceBanner>().Select(banner => ServiceBannerDto.FromBanner(banner)).ToList();
        return new GetBannersResult(goods, services);
    }
}