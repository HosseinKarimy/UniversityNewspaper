using Application.Bazaar.BazzarRepositories;
using Domain.Enums;
using Domain.Models;
using Domain.StronglyTypes;
using MediatR;

namespace Application.Bazaar.BazzarHandlers.DeleteBanner;

public class DeleteBannerHandler(IBazaarUnitOfWork bazaarUnitOfWork) : IRequestHandler<DeleteBannerCommand, DeleteBannerResult>
{
    public async Task<DeleteBannerResult> Handle(DeleteBannerCommand request, CancellationToken cancellationToken)
    {
        return request.BannerType switch
        {
            BannerType.Goods => await DeleteProcessAsync(bazaarUnitOfWork.GoodBannerRepository),
            BannerType.Service => await DeleteProcessAsync(bazaarUnitOfWork.ServiceBannerRepository),
            _ => throw new Exception(),
        };

        async Task<DeleteBannerResult> DeleteProcessAsync<T>(IBannerRepository<T> bannerRepository) where T : Banner
        {
            var userId = request.ContextCarrier.AuthenticatedUser!.Id;
            var banner = await bannerRepository.GetByIdAsync(BannerId.Of(request.BannerId), cancellationToken);

            //todo: check if banner is null
            AuthorizeRequest(banner, userId);

            bannerRepository.Delete(banner);
            await bazaarUnitOfWork.SaveChangesAsync(cancellationToken);

            return new DeleteBannerResult("success");


            void AuthorizeRequest(Banner banner, UserId requestUserId)
            {
                if (banner.OwnerId != requestUserId)
                    throw new Exception("Unauthorized");
            }
        }

    }    
}
