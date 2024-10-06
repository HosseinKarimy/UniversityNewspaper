using Domain.Models;
using Domain.StronglyTypes;

namespace Application.DTO;

public class BannerDTO
{
    public Guid BannerId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public Guid OwnerId { get; set; }
    public Guid CategoryId { get; set; }
    public string Image { get; set; }   

    public Banner ToBanner()
    {
        return new Banner()
        {
            BannerId = Domain.StronglyTypes.BannerId.Of(BannerId),
            CategoryId = Domain.StronglyTypes.CategoryId.Of(CategoryId),
            OwnerId = UserId.Of(OwnerId),
            CreatedAt = DateTime.Now,
            Description = Domain.StronglyTypes.Description.Of(Description),
            Title = Domain.StronglyTypes.Title.Of(Title),
            Image = ImageURL.Of(Image)
        };
    }

    public static BannerDTO FromBanner(Banner banner)
    {
        return new BannerDTO()
        {
            BannerId = banner.BannerId.Value,
            CategoryId = banner.CategoryId.Value,
            OwnerId = banner.OwnerId.Value,
            Description = banner.Description.Value,
            Title = banner.Title.Value,
            Image = banner.Image.Value
        };
    }
}
