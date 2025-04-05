using Helper.CQRS;
using Helper.HelperModels;

namespace Application.Bazaar.BazzarHandlers.DeleteBanner;

public record DeleteBannerCommand(Guid BannerId) : ICommand<DeleteBannerResult>
{
    public ImportantHttpContextCarrier ContextCarrier { get; set; } = new();
}

public record class DeleteBannerResult(string Message);
