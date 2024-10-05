using Application.BazaarRepositories;
using Application.DTO;
using Domain.Models;
using MediatR;

namespace Application.BazzarHandlers;

public record GetBannersQuery() : IRequest<GetBannerResult>;
public record GetBannerResult(List<BannerDTO> BannerDTOs);

public class GetBannersHandler(IBannerRepository bannerRepository) : IRequestHandler<GetBannersQuery, GetBannerResult>
{
    public async Task<GetBannerResult> Handle(GetBannersQuery request, CancellationToken cancellationToken)
    {
        List<Banner> banners = await bannerRepository.GetBannerAsync(cancellationToken);
        List<BannerDTO> bannerDTOs = banners.Select(banner => BannerDTO.FromBanner(banner)).ToList();
        return new GetBannerResult(bannerDTOs);
    }
}
