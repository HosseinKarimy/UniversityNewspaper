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
        var banner = CreateNewBanner((request.BannerDto as AddGoodBannerDto), request.ContextCarrier.AuthenticatedUser.Id.Value);
        var newbanner = await bazaarUnitOfWork.BannerRepository.AddAsync(banner, cancellationToken);
        await bazaarUnitOfWork.SaveChangesAsync(cancellationToken);
        return new AddBannerResult(newbanner.Id.Value);
    }

    private static GoodBanner CreateNewBanner(AddGoodBannerDto goodBannerDto, int userId) => new()
    {
        Id = BannerId.Of(Guid.NewGuid()),
        CategoryId = CategoryId.Of(goodBannerDto.CategoryId),
        OwnerId = UserId.Of(userId),
        CreatedAt = DateTime.Now,
        Description = goodBannerDto.Description,
        Title = goodBannerDto.Title,
        ImageUrl = goodBannerDto.Image,
        Price = CurrencyUnit.Of(goodBannerDto.Price)
    };
}
