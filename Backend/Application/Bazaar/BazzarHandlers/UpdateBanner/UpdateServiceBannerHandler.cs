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
        var userId = request.ContextCarrier.AuthenticatedUser!.Id;
        var banner = await bazaarUow.BannerRepository.GetByIdAsync(BannerId.Of(request.BannerId), cancellationToken) as ServiceBanner;
        AuthorizeRequest(banner, userId);
        UpdateBannerObject(banner!, request.Banner);
        bazaarUow.BannerRepository.Update(banner!);
        await bazaarUow.SaveChangesAsync(cancellationToken);
        return new UpdateBannerResult(true);
    }


    private static void UpdateBannerObject(ServiceBanner banner, UpdateServiceBannerDto bannerDto)
    {
        banner.CategoryId = CategoryId.Of(bannerDto.CategoryId);
        banner.Description = bannerDto.Description;
        banner.Title = bannerDto.Title;
        banner.ImageUrl = bannerDto.Image;
    }

    private static void AuthorizeRequest(ServiceBanner? banner, UserId requestUserId)
    {
        ArgumentNullException.ThrowIfNull(banner);
        if (banner.OwnerId != requestUserId)
            throw new Exception("Unauthorized");
    }
}
