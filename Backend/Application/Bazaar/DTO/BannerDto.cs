using Domain.Models;

namespace Application.Bazaar.DTO;

public abstract record BannerDto(
    Guid BannerId,
    string Title,
    string Description,
    int OwnerId,
    Guid CategoryId,
    DateTime CreatedAt,
    string? Image
);

public record GoodBannerDto(
    Guid BannerId,
    string Title,
    string Description,
    int OwnerId,
    Guid CategoryId,
    DateTime CreatedAt,
    string? Image,
    decimal price
    ) : BannerDto (BannerId, Title, Description, OwnerId, CategoryId, CreatedAt, Image)
{
    public static GoodBannerDto FromBanner(GoodBanner goodBanner)
    {
        return new GoodBannerDto(
            goodBanner.Id.Value,
            goodBanner.Title,
            goodBanner.Description,
            goodBanner.OwnerId.Value,
            goodBanner.CategoryId.Value.Value,
            goodBanner.CreatedAt,
            goodBanner.ImageUrl,
            goodBanner.Price.Value
        );
    }
}

public record ServiceBannerDto(
    Guid BannerId,
    string Title,
    string Description,
    int OwnerId,
    Guid CategoryId,
    DateTime CreatedAt,
    string? Image,
    string ServiceType
    ) : BannerDto(BannerId, Title, Description, OwnerId, CategoryId, CreatedAt, Image)
{
    public static ServiceBannerDto FromBanner(ServiceBanner serviceBanner)
    {
        return new ServiceBannerDto(
            serviceBanner.Id.Value,
            serviceBanner.Title,
            serviceBanner.Description,
            serviceBanner.OwnerId.Value,
            serviceBanner.CategoryId.Value.Value,
            serviceBanner.CreatedAt,
            serviceBanner.ImageUrl,
            serviceBanner.ServiceType
        );
    }
}
