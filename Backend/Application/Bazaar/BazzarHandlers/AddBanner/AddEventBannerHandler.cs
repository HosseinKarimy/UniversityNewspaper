using Helper.CQRS;

namespace Application.Bazaar.BazzarHandlers.AddBanner;

public class AddEventBannerHandler : ICommandHandler<AddEventBannerCommand, AddBannerResult>
{
    public Task<AddBannerResult> Handle(AddEventBannerCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
