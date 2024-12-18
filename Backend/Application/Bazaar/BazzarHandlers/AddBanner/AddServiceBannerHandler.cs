using Helper.CQRS;

namespace Application.Bazaar.BazzarHandlers.AddBanner;

public class AddServiceBannerHandler : ICommandHandler<AddServiceBannerCommand, AddBannerResult>
{
    public Task<AddBannerResult> Handle(AddServiceBannerCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
