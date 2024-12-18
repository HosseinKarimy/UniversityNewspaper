using Domain.Models;

namespace Application.Bazaar.DTO;

public abstract record AddBannerDto(
    string Title,
    string Description,
    Guid CategoryId,
    string Image,
    List<Guid> TagIds
);

public record AddGoodBannerDto(string Title, string Description, Guid CategoryId, string Image, List<Guid> TagIds, decimal Price)
    : AddBannerDto(Title, Description, CategoryId, Image, TagIds);

public record AddServiceBannerDto(string Title, string Description, Guid CategoryId, string Image, List<Guid> TagIds)
    : AddBannerDto(Title, Description, CategoryId, Image, TagIds);

public record AddEventBannerDto(string Title, string Description, Guid CategoryId, string Image, List<Guid> TagIds)
    : AddBannerDto(Title, Description, CategoryId, Image, TagIds);
