using Application.Bazaar.BazzarRepositories;
using Application.Bazaar.DTO;
using Domain.Enums;
using Helper.CQRS;

namespace Application.Bazaar.BazzarHandlers.GetBanners;

public class GetBannersHandler(IBazaarUnitOfWork bazaarUnitOfWork) : IQueryHandler<GetBannersQuery, GetBannersResult>
{
    public async Task<GetBannersResult> Handle(GetBannersQuery request, CancellationToken cancellationToken)
    {
        switch (request.RequestedBannerType)
        {
            case BannerType.Goods:
               var goods = await bazaarUnitOfWork.GoodBannerRepository.GetAllAsync(cancellationToken);
                return new GetBannersResult(goods.Select(banner => (GetBannerDto)GetGoodBannerDto.FromBanner(banner)).ToList());
            case BannerType.Service:
                var services = await bazaarUnitOfWork.ServiceBannerRepository.GetAllAsync(cancellationToken);
                return new GetBannersResult(services.Select(banner => (GetBannerDto)GetServiceBannerDto.FromBanner(banner)).ToList());
                
            default:
                throw new Exception();
        }
    }
}