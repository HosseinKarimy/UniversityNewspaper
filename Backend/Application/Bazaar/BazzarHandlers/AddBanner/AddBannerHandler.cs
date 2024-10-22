using Application.Bazaar.BazzarRepositories;
using Application.Bazaar.DTO;
using Domain.Models;
using Domain.StronglyTypes;
using Helper.CQRS;
using System.Diagnostics;
namespace Application.Bazaar.BazzarHandlers.AddBanner;

public class AddBannerHandler(IBannerRepository bannerRepository, IUserRepository userRepository) : ICommandHandler<AddBannerCommand, AddBannerResult>
{
    public async Task<AddBannerResult> Handle(AddBannerCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository.AddUserIfNotExistAsync(CreateNewUser(request.ContextCarrier.AuthenticatedUserId), cancellationToken);
        var banner = CreateNewBanner(request.BannerDto, user.UserId.Value);
        banner = await bannerRepository.AddBannerAsync(banner, cancellationToken);
        return new AddBannerResult(banner.BannerId.Value);
    }

    private User CreateNewUser(int userId) => new() { UserId = UserId.Of(userId) };

    private static GoodsBanner CreateNewBanner(AddBannerDto bannerDto, int userId) => new()
    {
        BannerId = BannerId.Of(Guid.NewGuid()),
        CategoryId = CategoryId.Of(bannerDto.CategoryId),
        OwnerId = UserId.Of(userId),
        CreatedAt = DateTime.Now,
        Description = Description.Of(bannerDto.Description),
        Title = Title.Of(bannerDto.Title),
        Image = ImageURL.Of(bannerDto.Image),
        //Price = CurrencyUnit.Of(bannerDto.Price)
        Price = bannerDto.Price
    };
}
