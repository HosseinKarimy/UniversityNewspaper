using Application.Bazaar.BazzarRepositories;
using Application.Bazaar.DTO;
using Domain.Models;
using Domain.StronglyTypes;
using FluentValidation;
using Helper.CQRS;
using Helper.HelperModels;

namespace Application.Bazaar.BazzarHandlers.AddBanner;

public record AddBannerCommand(AddBannerDto BannerDto) : ICommand<AddBannerResult>
{
    public ImportantHttpContextCarrier ContextCarrier { get; set; } = new();
}

public record AddBannerResult(Guid BannerId);

public class AddBannerHandler(IBannerRepository bannerRepository, IUserRepository userRepository) : ICommandHandler<AddBannerCommand, AddBannerResult>
{
    public async Task<AddBannerResult> Handle(AddBannerCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository.AddUserIfNotExistAsync(CreateNewUser(request.ContextCarrier.AuthenticatedUserId));
        var banner = CreateNewBanner(request.BannerDto, user.UserId.Value);
        banner = await bannerRepository.AddBannerAsync(banner, cancellationToken);
        return new AddBannerResult(banner.BannerId.Value);
    }

    private User CreateNewUser(int userId) => new User() { UserId = UserId.Of(userId) };

    private static Banner CreateNewBanner(AddBannerDto bannerDto, int userId) => new()
    {
        BannerId = BannerId.Of(Guid.NewGuid()),
        CategoryId = CategoryId.Of(bannerDto.CategoryId),
        OwnerId = UserId.Of(userId),
        CreatedAt = DateTime.Now,
        Description = Description.Of(bannerDto.Description),
        Title = Title.Of(bannerDto.Title),
        Image = ImageURL.Of(bannerDto.Image),
        Price = CurrencyUnit.Of(bannerDto.Price)
    };
}


public class AddBannerValidaion : AbstractValidator<AddBannerCommand>
{
    public AddBannerValidaion()
    {
        RuleFor(p => p.BannerDto.Title).NotEmpty().MinimumLength(2);
        RuleFor(p => p.BannerDto.CategoryId).NotEmpty();
        RuleFor(p => p.BannerDto.Price).NotEmpty().GreaterThan(0);
    }
}
