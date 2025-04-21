namespace Application.Bazaar.DTO;

public record UpdateBannerDto(
    string Title,
    string? Description,
    Guid CategoryId,
    string? Image,
    decimal? Price
);