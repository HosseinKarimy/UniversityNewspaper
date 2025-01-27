using Domain.Models;

namespace Application.Bazaar.DTO;

public abstract record GetBannerDto(
    Guid BannerId,
    string Title,
    string Description,
    int OwnerId,
    Guid CategoryId,
    DateTime CreatedAt,
    string Image
);

public record GetGoodBannerDto(
    Guid BannerId,
    string Title,
    string Description,
    int OwnerId,
    Guid CategoryId,
    DateTime CreatedAt,
    string Image,
    decimal price
    ) : GetBannerDto (BannerId, Title, Description, OwnerId, CategoryId, CreatedAt, Image)
{
    public static GetGoodBannerDto FromBanner(GoodBanner goodBanner)
    {
        return new GetGoodBannerDto(
            goodBanner.BannerId.Value,
            goodBanner.Title.Value,
            goodBanner.Description.Value,
            goodBanner.OwnerId.Value,
            goodBanner.CategoryId.Value.Value,
            goodBanner.CreatedAt,
            goodBanner.Image.Value,
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
    string Image,
    string ServiceType
    ) : GetBannerDto(BannerId, Title, Description, OwnerId, CategoryId, CreatedAt, Image)
{
    public static GetServiceBannerDto FromBanner(ServiceBanner serviceBanner)
    {
        return new GetServiceBannerDto(
            serviceBanner.BannerId.Value,
            serviceBanner.Title.Value,
            serviceBanner.Description.Value,
            serviceBanner.OwnerId.Value,
            serviceBanner.CategoryId.Value.Value,
            serviceBanner.CreatedAt,
            serviceBanner.Image.Value,
            serviceBanner.ServiceType
        );
    }
}
