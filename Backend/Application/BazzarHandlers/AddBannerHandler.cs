using Application.BazaarRepositories;
using Application.DTO;
using Domain.Models;
using Domain.StronglyTypes;
using MediatR;

namespace Application.BazaarHandlers;


public record AddBannerCommand(BannerDTO BannerDto) : IRequest<AddBannerResult>;
public record AddBannerResult(BannerDTO Banner);

public class AddBannerHandler(IBannerRepository bannerRepository) : IRequestHandler<AddBannerCommand, AddBannerResult>
{
    public async Task<AddBannerResult> Handle(AddBannerCommand request, CancellationToken cancellationToken)
    {

        var banner = CreateNewBanner(request.BannerDto);
        banner = await bannerRepository.AddBannerAsync(banner, cancellationToken);
        return new AddBannerResult(BannerDTO.FromBanner(banner));
    }

    private Banner CreateNewBanner(BannerDTO bannerDto)
    {
        return new Banner()
        {
            BannerId = Domain.StronglyTypes.BannerId.Of(Guid.NewGuid()),
            CategoryId = Domain.StronglyTypes.CategoryId.Of(bannerDto.CategoryId),
            OwnerId = UserId.Of(bannerDto.OwnerId),
            CreatedAt = DateTime.Now,
            Description = Domain.StronglyTypes.Description.Of(bannerDto.Description),
            Title = Domain.StronglyTypes.Title.Of(bannerDto.Title),
            Image = ImageURL.Of(bannerDto.Image)
        };
    }
}
