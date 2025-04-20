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
        var bannersDto = banners.Select(b => BannerDto.FromBanner(b)).ToList();
        return new GetBannersResult(bannersDto);
    }
}