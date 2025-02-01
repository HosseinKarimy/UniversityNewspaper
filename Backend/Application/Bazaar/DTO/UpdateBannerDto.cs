namespace Application.Bazaar.DTO;

public abstract record UpdateBannerDto(
    string Title,
    string Description,
    Guid CategoryId,
    string Image,
    List<Guid> TagIds
);

public record UpdateGoodBannerDto(string Title, string Description, Guid CategoryId, string Image, List<Guid> TagIds, decimal Price)
    : UpdateBannerDto(Title, Description, CategoryId, Image, TagIds);

public record UpdateServiceBannerDto(string Title, string Description, Guid CategoryId, string Image, List<Guid> TagIds)
    : UpdateBannerDto(Title, Description, CategoryId, Image, TagIds);

public record UpdateEventBannerDto(string Title, string Description, Guid CategoryId, string Image, List<Guid> TagIds)
    : UpdateBannerDto(Title, Description, CategoryId, Image, TagIds);
