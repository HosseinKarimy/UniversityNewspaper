using Application.Bazaar.BazzarRepositories;
using Domain.Models;
using Domain.StronglyTypes;
using MediatR;

namespace Application.Bazaar.BazzarHandlers.DeleteBanner;

public class DeleteBannerHandler(IBazaarUnitOfWork bazaarUnitOfWork) : IRequestHandler<DeleteBannerCommand, DeleteBannerResult>
{
    public async Task<DeleteBannerResult> Handle(DeleteBannerCommand request, CancellationToken cancellationToken)
    {
        var userId = request.ContextCarrier.AuthenticatedUser!.Id;
        var banner = await bazaarUnitOfWork.BannerRepository.GetByIdAsync(BannerId.Of(request.BannerId), cancellationToken);

        //todo: check if banner is null
        AuthorizeRequest(banner, userId);

        bazaarUnitOfWork.BannerRepository.Delete(banner);
        await bazaarUnitOfWork.SaveChangesAsync(cancellationToken);

        return new DeleteBannerResult("success");

        void AuthorizeRequest(Banner banner, UserId requestUserId)
        {
            if (banner.OwnerId != requestUserId)
                throw new Exception("Unauthorized");
        }
    }
}
