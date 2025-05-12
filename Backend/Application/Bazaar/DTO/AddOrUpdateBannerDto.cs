namespace Application.Bazaar.DTO;

public record AddOrUpdateBannerDto(
    string Title,
    string? Description,
    Guid CategoryId,
    string? Image,
    string? Price
);