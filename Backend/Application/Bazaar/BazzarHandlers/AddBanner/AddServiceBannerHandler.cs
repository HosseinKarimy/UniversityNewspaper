using Application.Bazaar.BazzarRepositories;
using Application.Bazaar.DTO;
using Domain.Models;
using Domain.StronglyTypes;
using Helper.CQRS;

namespace Application.Bazaar.BazzarHandlers.AddBanner;

public class AddServiceBannerHandler(IBazaarUnitOfWork bazaarUnitOfWork) : ICommandHandler<AddServiceBannerCommand, AddBannerResult>
{
    public async Task<AddBannerResult> Handle(AddServiceBannerCommand request, CancellationToken cancellationToken)
    {
        var banner = CreateNewBanner((request.BannerDto as AddServiceBannerDto), request.ContextCarrier.AuthenticatedUser.UserId.Value);
        banner = await bazaarUnitOfWork.ServiceBannerRepository.AddAsync(banner, cancellationToken);
        await bazaarUnitOfWork.SaveChangesAsync(cancellationToken);
        return new AddBannerResult(banner.BannerId.Value);
    }

    private static ServiceBanner CreateNewBanner(AddServiceBannerDto? serviceBannerDto, int userId) => new()
    {
        BannerId = BannerId.Of(Guid.NewGuid()),
        CategoryId = CategoryId.Of(serviceBannerDto.CategoryId),
        OwnerId = UserId.Of(userId),
        CreatedAt = DateTime.Now,
        Description = Description.Of(serviceBannerDto.Description),
        Title = Title.Of(serviceBannerDto.Title),
        Image = ImageURL.Of(serviceBannerDto.Image)
    };
}
