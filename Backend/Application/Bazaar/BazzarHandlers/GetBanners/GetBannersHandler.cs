using Application.Bazaar.BazzarRepositories;
using Application.Bazaar.DTO;
using Domain.Enums;
using Domain.Models;
using Helper.CQRS;

namespace Application.Bazaar.BazzarHandlers.GetBanners;

public class GetBannersHandler(IBazaarUnitOfWork bazaarUnitOfWork) : IQueryHandler<GetBannersQuery, GetBannersResult>
{
    public async Task<GetBannersResult> Handle(GetBannersQuery request, CancellationToken cancellationToken)
    {
        var banners = request.RequestedBannerType switch
        {
            BannerType.Goods => await bazaarUnitOfWork.GoodBannerRepository.GetAllAsync(cancellationToken),
            BannerType.Service => throw new NotImplementedException(),
            BannerType.Event => throw new NotImplementedException(),
            _ => throw new NotImplementedException(),
        };

        return new GetBannersResult(banners.Select(banner => GetBannerDto.FromBanner(banner)).ToList());
    }
}