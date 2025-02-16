using Domain.Models;

namespace Application.Bazaar.DTO;

public abstract record GetBannerDto(
    Guid BannerId,
    string Title,
    string Description,
    int OwnerId,
    Guid CategoryId,
    DateTime CreatedAt,
    string? Image
);

public record GetGoodBannerDto(
    Guid BannerId,
    string Title,
    string Description,
    int OwnerId,
    Guid CategoryId,
    DateTime CreatedAt,
    string? Image,
    decimal price
    ) : GetBannerDto (BannerId, Title, Description, OwnerId, CategoryId, CreatedAt, Image)
{
    public static GetGoodBannerDto FromBanner(GoodBanner goodBanner)
    {
        return new GetGoodBannerDto(
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

public record GetServiceBannerDto(
    Guid BannerId,
    string Title,
    string Description,
    int OwnerId,
    Guid CategoryId,
    DateTime CreatedAt,
    string? Image,
    string ServiceType
    ) : GetBannerDto(BannerId, Title, Description, OwnerId, CategoryId, CreatedAt, Image)
{
    public static GetServiceBannerDto FromBanner(ServiceBanner serviceBanner)
    {
        return new GetServiceBannerDto(
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
