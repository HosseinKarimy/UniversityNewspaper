using Application.Bazaar.BazzarHandlers.AddBanner;
using Application.Bazaar.DTO;
using FluentValidation;
using Helper.CQRS;
using Helper.HelperModels;

namespace Application.Bazaar.BazzarHandlers.UpdateBanner;

public record UpdateBannerCommand(UpdateBannerDto BannerDto) : ICommand<UpdateBannerResult>
{
    public ImportantHttpContextCarrier ContextCarrier { get; set; } = new();
}

public record UpdateBannerResult(bool IsSuccess);


public class UpdateBannerValidaion : AbstractValidator<UpdateBannerCommand>
{
    public UpdateBannerValidaion()
    {
        RuleFor(p => p.BannerDto.BannerId).NotEmpty();
        RuleFor(p => p.BannerDto.Title).NotEmpty().MinimumLength(2);
        RuleFor(p => p.BannerDto.CategoryId).NotEmpty();
        RuleFor(p => p.BannerDto.Price).NotEmpty().GreaterThan(0);
    }
}