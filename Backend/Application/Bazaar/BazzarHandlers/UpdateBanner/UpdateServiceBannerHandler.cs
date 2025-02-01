using Application.Bazaar.BazzarRepositories;
using Application.Bazaar.DTO;
using Domain.Models;
using Domain.StronglyTypes;
using MediatR;

namespace Application.Bazaar.BazzarHandlers.UpdateBanner;

public class UpdateServiceBannerHandler(IBazaarUnitOfWork bazaarUow) : IRequestHandler<UpdateServiceBannerCommand, UpdateBannerResult>
{
    public async Task<UpdateBannerResult> Handle(UpdateServiceBannerCommand request, CancellationToken cancellationToken)
    {
        var userId = request.ContextCarrier.AuthenticatedUser!.UserId;
        var banner = await bazaarUow.ServiceBannerRepository.GetByIdAsync(BannerId.Of(request.BannerId), cancellationToken);
        AuthorizeRequest(banner, userId);
        UpdateBannerObject(banner!, request.Banner);
        bazaarUow.ServiceBannerRepository.Update(banner!);
        await bazaarUow.SaveChangesAsync(cancellationToken);
        return new UpdateBannerResult(true);
    }


    private static void UpdateBannerObject(ServiceBanner banner, UpdateServiceBannerDto bannerDto)
    {
        banner.CategoryId = CategoryId.Of(bannerDto.CategoryId);
        banner.Description = Description.Of(bannerDto.Description);
        banner.Title = Title.Of(bannerDto.Title);
        banner.Image = ImageURL.Of(bannerDto.Image);
    }

    private static void AuthorizeRequest(ServiceBanner? banner, UserId requestUserId)
    {
        ArgumentNullException.ThrowIfNull(banner);
        if (banner.OwnerId != requestUserId)
            throw new Exception("Unauthorized");
    }
}
