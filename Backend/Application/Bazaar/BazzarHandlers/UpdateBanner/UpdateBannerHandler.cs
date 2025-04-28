using Application.Bazaar.BazzarRepositories;
using Application.Bazaar.DTO;
using Domain.Models;
using Domain.StronglyTypes;
using MediatR;

namespace Application.Bazaar.BazzarHandlers.UpdateBanner;

public class UpdateBannerHandler(IBazaarUnitOfWork bazaarUow) : IRequestHandler<UpdateBannerCommand, UpdateBannerResult>
{
    public async Task<UpdateBannerResult> Handle(UpdateBannerCommand request, CancellationToken cancellationToken)
    {
        var userId = request.ContextCarrier.AuthenticatedUser!.Id;
        var banner = await bazaarUow.BannerRepository.GetByIdAsync(request.BannerId, cancellationToken) ?? throw new Exception("Banner not found");
        Authorization();
        UpdateBannerObject(banner, request.BannerDto);
        bazaarUow.BannerRepository.Update(banner);
        await bazaarUow.SaveChangesAsync(cancellationToken);
        return new UpdateBannerResult(true);

        void Authorization()
        {
            if (banner.OwnerId != userId)
                throw new Exception("Unauthorized");
        }
    }

    private static void UpdateBannerObject(Banner ExistingBanner, AddOrUpdateBannerDto UpdatedBanner)
    {
        ExistingBanner.CategoryId = CategoryId.Of(UpdatedBanner.CategoryId);
        ExistingBanner.Description = UpdatedBanner.Description;
        ExistingBanner.Title = UpdatedBanner.Title;
        ExistingBanner.ImageUrl = UpdatedBanner.Image;
        ExistingBanner.Price = UpdatedBanner.Price is null ? null : CurrencyUnit.Of(UpdatedBanner.Price.Value);
    }
}
