using Application.Bazaar.BazzarRepositories;
using Application.Exceptions;
using MediatR;

namespace Application.Bazaar.BazzarHandlers.DeleteBanner;

public class DeleteBannerHandler(IBazaarUnitOfWork bazaarUnitOfWork) : IRequestHandler<DeleteBannerCommand, DeleteBannerResult>
{
    public async Task<DeleteBannerResult> Handle(DeleteBannerCommand request, CancellationToken cancellationToken)
    {
        var userId = request.ContextCarrier.AuthenticatedUser!.Id;
        var banner = await bazaarUnitOfWork.BannerRepository.GetByIdAsync(request.BannerId, cancellationToken) ?? throw new Exception("Banner Not Found");

        Authorization();

        bazaarUnitOfWork.BannerRepository.Delete(banner);
        await bazaarUnitOfWork.SaveChangesAsync(cancellationToken);

        return new DeleteBannerResult("success");

        void Authorization()
        {
            if (banner.OwnerId != userId)
                throw new UnauthorizedExeption();
        }
    }
}
