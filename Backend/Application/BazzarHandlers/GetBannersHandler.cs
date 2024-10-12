using Application.BazaarRepositories;
using Application.CQRS;
using Application.DTO;
using Domain.Models;
using MediatR;

namespace Application.BazzarHandlers;

public record GetBannersQuery() : IQuery<GetBannerResult>;
public record GetBannerResult(List<GetBannerDto> BannerDTOs);

public class GetBannersHandler(IBannerRepository bannerRepository) : IQueryHandler<GetBannersQuery, GetBannerResult>
{
    public async Task<GetBannerResult> Handle(GetBannersQuery request, CancellationToken cancellationToken)
    {
        List<Banner> banners = await bannerRepository.GetBannerAsync(cancellationToken);
        List<GetBannerDto> bannerDTOs = banners.Select(banner => GetBannerDto.FromBanner(banner)).ToList();
        return new GetBannerResult(bannerDTOs);
    }
}
