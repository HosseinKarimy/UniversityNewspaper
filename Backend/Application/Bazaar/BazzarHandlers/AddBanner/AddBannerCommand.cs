using Application.Bazaar.DTO;
using FluentValidation;
using Helper.CQRS;
using Helper.HelperModels;

namespace Application.Bazaar.BazzarHandlers.AddBanner;

//base Command
public abstract record AddBannerCommand(AddBannerDto BannerDto) : ICommand<AddBannerResult>
{
    public ImportantHttpContextCarrier ContextCarrier { get; set; } = new();
}

//base result
public record AddBannerResult(Guid BannerId);

//base validation rules
public abstract class AddBannerValidation<TCommand> : AbstractValidator<TCommand> where TCommand : AddBannerCommand
{
    public AddBannerValidation()
    {
        RuleFor(p => p.BannerDto.Title).NotEmpty().MinimumLength(2);
        RuleFor(p => p.BannerDto.CategoryId).NotEmpty();
    }
}



public record AddGoodBannerCommand : AddBannerCommand
{
    public AddGoodBannerCommand(AddGoodBannerDto GoodBannerDto) : base(GoodBannerDto)
    {
    }
}

public class AddGoodBannerValidation : AddBannerValidation<AddGoodBannerCommand>
{
    public AddGoodBannerValidation() : base()
    {
        RuleFor(p => (p.BannerDto as AddGoodBannerDto)!.Price).NotEmpty().GreaterThan(0);
    }
}



public record AddServiceBannerCommand : AddBannerCommand
{
    public AddServiceBannerCommand(AddServiceBannerDto ServiceBannerDto) : base(ServiceBannerDto)
    {
    }
}

public class AddServiceBannerValidaion : AddBannerValidation<AddServiceBannerCommand>
{
    public AddServiceBannerValidaion() : base()
    {

    }
}



public record AddEventBannerCommand : AddBannerCommand
{
    public AddEventBannerCommand(AddEventBannerDto EventBannerDto) : base(EventBannerDto)
    {
    }
}
public class AddEventBannerValidation : AddBannerValidation<AddEventBannerCommand>
{
    public AddEventBannerValidation() : base()
    {
       
    }
}
