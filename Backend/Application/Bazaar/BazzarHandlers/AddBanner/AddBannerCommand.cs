using Application.Bazaar.DTO;
using FluentValidation;
using Helper.CQRS;
using Helper.HelperModels;

namespace Application.Bazaar.BazzarHandlers.AddBanner;

//request
public record AddBannerCommand(AddBannerDto BannerDto) : ICommand<AddBannerResult>
{
    public ImportantHttpContextCarrier ContextCarrier { get; set; } = new();
}

//response
public record AddBannerResult(Guid BannerId);

//validation
public class AddBannerValidaion : AbstractValidator<AddBannerCommand>
{
    public AddBannerValidaion()
    {
        RuleFor(p => p.BannerDto.Title).NotEmpty().MinimumLength(2);
        RuleFor(p => p.BannerDto.CategoryId).NotEmpty();
        RuleFor(p => p.BannerDto.Price).NotEmpty().GreaterThan(0);
    }
}
