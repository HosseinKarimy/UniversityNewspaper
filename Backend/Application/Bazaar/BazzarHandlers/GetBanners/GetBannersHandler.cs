using Application.Bazaar.BazzarRepositories;
using Application.Bazaar.DTO;
using Domain.Models;
using Helper.CQRS;

namespace Application.Bazaar.BazzarHandlers.GetBanners;

public class GetBannersHandler(IBazaarUnitOfWork bazaarUnitOfWork) : IQueryHandler<GetBannersQuery, PaginatedResult<BannerDto>>
{
    public async Task<PaginatedResult<BannerDto>> Handle(GetBannersQuery request, CancellationToken cancellationToken)
    {
        var banners = await bazaarUnitOfWork.BannerRepository.GetFilteredBannres(request.Filters , cancellationToken);
        var bannersDto = banners.Select(b => BannerDto.FromBanner(b)).ToList();
        return new PaginatedResult<BannerDto>(bannersDto , request.Filters.Page , request.Filters.PageSize);
    }
}