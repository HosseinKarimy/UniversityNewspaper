using Domain.Models;

namespace Application.Bazaar.DTO;

public abstract record AddBannerDto(
    string Title,
    string Description,
    Guid CategoryId,
    string Image
);

public record AddGoodBannerDto(string Title, string Description, Guid CategoryId, string Image,  decimal Price)
    : AddBannerDto(Title, Description, CategoryId, Image);

public record AddServiceBannerDto(string Title, string Description, Guid CategoryId, string Image)
    : AddBannerDto(Title, Description, CategoryId, Image);