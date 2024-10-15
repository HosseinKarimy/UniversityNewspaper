using Application.Bazaar.DTO;
using Helper.CQRS;
using Helper.HelperModels;

namespace Application.Bazaar.BazzarHandlers;


public record UpdateBannerCommand(UpdateBannerDto BannerDto) : ICommand<UpdateBannerResult>
{
    public ImportantHttpContextCarrier ContextCarrier { get; set; } = new();
}

public record UpdateBannerResult(bool IsSuccess);


public class UpdateBannerHandler : ICommandHandler<UpdateBannerCommand, UpdateBannerResult>
{
    public Task<UpdateBannerResult> Handle(UpdateBannerCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
