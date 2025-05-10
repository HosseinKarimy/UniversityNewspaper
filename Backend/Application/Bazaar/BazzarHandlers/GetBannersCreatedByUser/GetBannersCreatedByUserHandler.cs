using Application.Bazaar.BazzarHandlers.GetBanners;
using Application.Bazaar.BazzarRepositories;
using Application.Bazaar.DTO;
using Application.Exceptions;
using Domain.Models;
using Helper.CQRS;

namespace Application.Bazaar.BazzarHandlers.GetMyBanners;

public class GetBannersCreatedByUserHandler(IBazaarUnitOfWork bannerRepository) : IQueryHandler<GetBannersCreatedByUserQuery, GetBannersResult>
{
    public async Task<GetBannersResult> Handle(GetBannersCreatedByUserQuery request, CancellationToken cancellationToken)
    {
        Authorization();
        List<Banner> banners = await bannerRepository.BannerRepository.GetBannersCreatedByUser(request.UserId, cancellationToken);
        var BannersDto = banners.Select(banner => BannerDto.FromBanner(banner)).ToList();

        return new GetBannersResult(BannersDto);

        void Authorization()
        {
            if (request.ContextCarrier.AuthenticatedUser!.Id != request.UserId)
                throw new UnauthorizedExeption();        
        }
    }

}
