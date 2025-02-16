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
        var banner = CreateNewBanner((request.BannerDto as AddServiceBannerDto), request.ContextCarrier.AuthenticatedUser.Id.Value);
        banner = await bazaarUnitOfWork.ServiceBannerRepository.AddAsync(banner, cancellationToken);
        await bazaarUnitOfWork.SaveChangesAsync(cancellationToken);
        return new AddBannerResult(banner.Id.Value);
    }

    private static ServiceBanner CreateNewBanner(AddServiceBannerDto? serviceBannerDto, int userId) => new()
    {
        Id = BannerId.Of(Guid.NewGuid()),
        CategoryId = CategoryId.Of(serviceBannerDto.CategoryId),
        OwnerId = UserId.Of(userId),
        CreatedAt = DateTime.Now,
        Description = serviceBannerDto.Description,
        Title = serviceBannerDto.Title,
        ImageUrl = serviceBannerDto.Image
    };
}
