using Application.Bazaar.BazzarRepositories;
using Application.Bazaar.DTO;
using Domain.Models;
using Domain.StronglyTypes;
using Helper.CQRS;
namespace Application.Bazaar.BazzarHandlers.AddBanner;

public class AddGoodBannerHandler(IBazaarUnitOfWork bazaarUnitOfWork) : ICommandHandler<AddGoodBannerCommand, AddBannerResult>
{
    public async Task<AddBannerResult> Handle(AddGoodBannerCommand request, CancellationToken cancellationToken)
    {
        var banner = CreateNewBanner((request.BannerDto as AddGoodBannerDto), request.ContextCarrier.AuthenticatedUser.UserId.Value);
        banner = await bazaarUnitOfWork.GoodBannerRepository.AddAsync(banner, cancellationToken);
        await bazaarUnitOfWork.SaveChangesAsync(cancellationToken);
        return new AddBannerResult(banner.BannerId.Value);
    }

    private static GoodBanner CreateNewBanner(AddGoodBannerDto goodBannerDto, int userId) => new()
    {
        BannerId = BannerId.Of(Guid.NewGuid()),
        CategoryId = CategoryId.Of(goodBannerDto.CategoryId),
        OwnerId = UserId.Of(userId),
        CreatedAt = DateTime.Now,
        Description = Description.Of(goodBannerDto.Description),
        Title = Title.Of(goodBannerDto.Title),
        Image = ImageURL.Of(goodBannerDto.Image),
        Price = CurrencyUnit.Of(goodBannerDto.Price)
    };
}
