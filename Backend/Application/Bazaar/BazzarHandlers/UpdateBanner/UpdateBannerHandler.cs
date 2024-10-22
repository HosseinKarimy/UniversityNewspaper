using Application.Bazaar.BazzarRepositories;
using Application.Bazaar.DTO;
using Domain.Models;
using Domain.StronglyTypes;
using Helper.CQRS;
using System.Diagnostics;

namespace Application.Bazaar.BazzarHandlers.UpdateBanner;


public class UpdateBannerHandler(IBannerRepository bannerRepository) : ICommandHandler<UpdateBannerCommand, UpdateBannerResult>
{
    public async Task<UpdateBannerResult> Handle(UpdateBannerCommand request, CancellationToken cancellationToken)
    {
        var banner = await GetBannersAsync(request.BannerDto, cancellationToken);
        AuthorizeRequest(banner, request);
        UpdateBannerObject(banner, request.BannerDto);
        var isSuccess = await bannerRepository.UpdateBannerAsync(banner, cancellationToken);
        return new UpdateBannerResult(isSuccess);
    }

    private async Task<GoodsBanner> GetBannersAsync(UpdateBannerDto bannerDto, CancellationToken cancellationToken)
    {
        var banner = await bannerRepository.GetBannersByIdAsync(BannerId.Of(bannerDto.BannerId), cancellationToken);
        return banner ?? throw new Exception("banner not found");
    }

    private static void UpdateBannerObject(GoodsBanner banner, UpdateBannerDto bannerDto)
    {
        banner.CategoryId = CategoryId.Of(bannerDto.CategoryId);
        banner.Description = Description.Of(bannerDto.Description);
        banner.Title = Title.Of(bannerDto.Title);
        banner.Image = ImageURL.Of(bannerDto.Image);
        //banner.Price = CurrencyUnit.Of(bannerDto.Price);
        banner.Price = bannerDto.Price;
    }

    private static void AuthorizeRequest(GoodsBanner banner, UpdateBannerCommand request)
    {
        if (banner.OwnerId.Value != request.ContextCarrier.AuthenticatedUserId)
            throw new Exception("Unauthorized");
    }
}
