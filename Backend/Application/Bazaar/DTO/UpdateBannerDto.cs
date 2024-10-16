namespace Application.Bazaar.DTO;

public record UpdateBannerDto(
    Guid BannerId,
    string Title,
    string Description,
    Guid CategoryId,
    string Image,
    decimal Price
);