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
    public List<string> Images { get; set; }   

    public Banner ToBanner()
    {
        return new Banner()
        {
            BannerId = new BannerId(BannerId),
            CategoryId = new CategoryId(CategoryId),
            OwnerId = new UserId(OwnerId),
            CreatedAt = DateTime.Now,
            Description = new Description(Description),
            Title = new Title(Title),
            Images = Images.Select(image => new ImageURL(image)).ToList()
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
            Images = banner.Images.Select(imageUrl => imageUrl.Value).ToList()
        };
    }
}
