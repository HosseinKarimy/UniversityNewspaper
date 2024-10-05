using Domain.Models;
using Domain.StronglyTypes;

namespace Application.DTO;

public class BannerDTO
{
    public Guid bannerId { get; set; }
    public string title { get; set; }
    public string description { get; set; }
    public Guid ownerId { get; set; }
    public Guid categoryId { get; set; }
    public string image { get; set; }   

    public Banner ToBanner()
    {
        return new Banner()
        {
            BannerId = BannerId.Of(bannerId),
            CategoryId =  CategoryId.Of(categoryId),
            OwnerId =  UserId.Of(ownerId),
            CreatedAt = DateTime.Now,
            Description =  Description.Of(description),
            Title =  Title.Of(title),
            Image = ImageURL.Of(image)
        };
    }

    public static BannerDTO FromBanner(Banner banner)
    {
        return new BannerDTO()
        {
            bannerId = banner.BannerId.Value,
            categoryId = banner.CategoryId.Value,
            ownerId = banner.OwnerId.Value,
            description = banner.Description.Value,
            title = banner.Title.Value,
            image = banner.Image.Value
        };
    }
}
