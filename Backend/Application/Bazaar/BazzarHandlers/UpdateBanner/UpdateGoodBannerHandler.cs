using Application.Bazaar.BazzarRepositories;
using Application.Bazaar.DTO;
using Domain.Models;
using Domain.StronglyTypes;
using MediatR;

namespace Application.Bazaar.BazzarHandlers.UpdateBanner;

public class UpdateGoodBannerHandler(IBazaarUnitOfWork bannerRepository) : IRequestHandler<UpdateGoodBannerCommand, UpdateBannerResult>
{
    public async Task<UpdateBannerResult> Handle(UpdateGoodBannerCommand request, CancellationToken cancellationToken)
    {
        var userId = request.ContextCarrier.AuthenticatedUser!.UserId;
        var banner = await bannerRepository.GoodBannerRepository.GetByIdAsync(BannerId.Of(request.BannerId) , cancellationToken);
        AuthorizeRequest(banner, userId);
        UpdateBannerObject(banner, request.Banner);
        bannerRepository.GoodBannerRepository.Update(banner);
        await bannerRepository.SaveChangesAsync(cancellationToken);
        return new UpdateBannerResult(true);
    }

    private static void UpdateBannerObject(GoodBanner banner, UpdateGoodBannerDto bannerDto)
    {
        banner.CategoryId = CategoryId.Of(bannerDto.CategoryId);
        banner.Description = Description.Of(bannerDto.Description);
        banner.Title = Title.Of(bannerDto.Title);
        banner.Image = ImageURL.Of(bannerDto.Image);
        banner.Price = CurrencyUnit.Of(bannerDto.Price);
    }

    private static void AuthorizeRequest(GoodBanner banner, UserId requestUserId)
    {
        if (banner.OwnerId != requestUserId)
            throw new Exception("Unauthorized");
    }
}
