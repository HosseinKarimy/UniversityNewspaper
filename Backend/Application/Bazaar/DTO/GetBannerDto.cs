using Domain.Models;

namespace Application.Bazaar.DTO;

public record GetBannerDto(
    Guid BannerId,
    string Title,
    string Description,
    User Owner,
    Category Category,
    DateTime CreatedAt,
    string Image
)
{
    public static GetBannerDto FromBanner(GoodBanner banner)
    {
        return new GetBannerDto(
            banner.BannerId.Value,
            banner.Title.Value,
            banner.Description.Value,
            banner.Owner,
            banner.Category,
            banner.CreatedAt,
            banner.Image.Value
        );
    }
}