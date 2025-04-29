using Application.Bazaar.BazzarRepositories;
using Application.Bazaar.DTO;
using Domain.Models;
using Domain.StronglyTypes;
using Helper.CQRS;
namespace Application.Bazaar.BazzarHandlers.AddBanner;

public class AddBannerHandler(IBazaarUnitOfWork bazaarUnitOfWork) : ICommandHandler<AddBannerCommand, AddBannerResult>
{
    public async Task<AddBannerResult> Handle(AddBannerCommand request, CancellationToken cancellationToken)
    {
        Authorization();

        var banner = CreateNewBanner(request.BannerDto, request.ContextCarrier.AuthenticatedUser!.Id.Value);
        var newbanner = await bazaarUnitOfWork.BannerRepository.AddAsync(banner, cancellationToken);
        await bazaarUnitOfWork.SaveChangesAsync(cancellationToken);
        return new AddBannerResult(newbanner.Id.Value);

        void Authorization()
        {
            if (request.ContextCarrier.AuthenticatedUser!.CanAddBanner is false)
            {
                throw new Exception("Access Denied");
            }
        }
    }

    private static Banner CreateNewBanner(AddOrUpdateBannerDto BannerDto, int userId) => new()
    {
        Id = BannerId.Of(Guid.NewGuid()),
        CategoryId = CategoryId.Of(BannerDto.CategoryId),
        OwnerId = UserId.Of(userId),
        CreatedAt = DateTime.Now,
        Description = BannerDto.Description,
        Title = BannerDto.Title,
        ImageUrl = BannerDto.Image,
        Price = BannerDto.Price is null ? null : CurrencyUnit.Of(BannerDto.Price.Value),
    };
}
