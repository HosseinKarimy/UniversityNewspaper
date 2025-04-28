using Application.Bazaar.DTO;
using FluentValidation;
using Helper.CQRS;
using Helper.HelperModels;

namespace Application.Bazaar.BazzarHandlers.AddBanner;

public record AddBannerCommand(AddOrUpdateBannerDto BannerDto) : ICommand<AddBannerResult>
{
    public ImportantHttpContextCarrier ContextCarrier { get; set; } = new();
}

public record AddBannerResult(Guid BannerId);

public class AddBannerValidation : AbstractValidator<AddBannerCommand>
{
    public AddBannerValidation()
    {
        RuleFor(p => p.BannerDto.Title).NotEmpty().MinimumLength(2);
        RuleFor(p => p.BannerDto.CategoryId).NotEmpty();
    }
}
