using Application.Bazaar.DTO;
using Domain.StronglyTypes;
using FluentValidation;
using Helper.CQRS;
using Helper.HelperModels;

namespace Application.Bazaar.BazzarHandlers.UpdateBanner;

public record UpdateBannerCommand(BannerId BannerId , UpdateBannerDto BannerDto) : ICommand<UpdateBannerResult>
{
    public ImportantHttpContextCarrier ContextCarrier { get; set; } = new();
}

public class UpdateBannerValidaion : AbstractValidator<UpdateBannerCommand>
{
    public UpdateBannerValidaion()
    {
        RuleFor(p => p.BannerDto.Title).NotEmpty().MinimumLength(2);
        RuleFor(p => p.BannerDto.CategoryId).NotEmpty();
    }
}

public record UpdateBannerResult(bool IsSuccess);

