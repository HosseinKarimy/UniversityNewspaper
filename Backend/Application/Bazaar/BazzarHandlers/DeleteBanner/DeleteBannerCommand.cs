using Domain.StronglyTypes;
using Helper.CQRS;
using Helper.HelperModels;
using MediatR;

namespace Application.Bazaar.BazzarHandlers.DeleteBanner;

public record DeleteBannerCommand(BannerId BannerId) : ICommand<Unit>
{
    public ImportantHttpContextCarrier ContextCarrier { get; set; } = new();
}