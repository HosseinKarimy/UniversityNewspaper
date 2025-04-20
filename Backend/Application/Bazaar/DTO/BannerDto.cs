using Domain.Models;

namespace Application.Bazaar.DTO;

public record BannerDto(
    Guid BannerId,
    string Title,
    string? Description,
    int OwnerId,
    Guid CategoryId,
    DateTime CreatedAt,
    string? Image,
    decimal? Price
)
{
    public static BannerDto FromBanner(Banner Banner)
    {
        return new BannerDto(
            Banner.Id.Value,
            Banner.Title,
            Banner.Description,
            Banner.OwnerId.Value,
            Banner.CategoryId.Value,
            Banner.CreatedAt,
            Banner.ImageUrl,
            Banner.Price?.Value
        );
    }
}
