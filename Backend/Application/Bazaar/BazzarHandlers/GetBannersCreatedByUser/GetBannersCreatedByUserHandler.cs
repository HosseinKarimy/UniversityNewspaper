using Application.Bazaar.BazzarHandlers.GetBanners;
using Application.Bazaar.BazzarRepositories;
using Application.Bazaar.DTO;
using Domain.Models;
using Helper.CQRS;

namespace Application.Bazaar.BazzarHandlers.GetMyBanners;

public class GetBannersCreatedByUserHandler(IBazaarUnitOfWork bannerRepository) : IQueryHandler<GetBannersCreatedByUserQuery, GetBannersResult>
{
    public async Task<GetBannersResult> Handle(GetBannersCreatedByUserQuery request, CancellationToken cancellationToken)
    {
        Authorization();
        List<Banner> banners = await bannerRepository.BannerRepository.GetBannersByUserID(request.UserId, cancellationToken);
        var BannersDto = banners.Select(banner => BannerDto.FromBanner(banner)).ToList();

        return new GetBannersResult(BannersDto);

        void Authorization()
        {
            if (request.ContextCarrier.AuthenticatedUser!.Id != request.UserId)
            throw new Exception("UnAuthorized"); // TODO: Create Custom Exception for this case            
        }
    }

}
