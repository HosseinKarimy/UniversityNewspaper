namespace Application.Bazaar.DTO;

public record AddBannerDto(
    string Title,
    string? Description,
    Guid CategoryId,
    string? Image,
    decimal? Price
);