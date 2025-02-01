using Application.Bazaar.DTO;
using FluentValidation;
using Helper.CQRS;
using Helper.HelperModels;

namespace Application.Bazaar.BazzarHandlers.UpdateBanner;

public abstract record UpdateBannerCommand(Guid BannerId , UpdateBannerDto BannerDto) : ICommand<UpdateBannerResult>
{
    public ImportantHttpContextCarrier ContextCarrier { get; set; } = new();
}

public abstract class UpdateBannerValidaion : AbstractValidator<UpdateBannerCommand>
{
    public UpdateBannerValidaion()
    {
        RuleFor(p => p.BannerDto.Title).NotEmpty().MinimumLength(2);
        RuleFor(p => p.BannerDto.CategoryId).NotEmpty();
    }
}

public record UpdateBannerResult(bool IsSuccess);




public record UpdateGoodBannerCommand(Guid BannerId, UpdateGoodBannerDto Banner) : UpdateBannerCommand(BannerId , Banner);
public class UpdateGoodBannerValidation : AbstractValidator<UpdateGoodBannerDto>
{
    public UpdateGoodBannerValidation() : base()
    {
        RuleFor(p=>p.Price).GreaterThanOrEqualTo(0);
    }
}
