using Domain.Models;

namespace Application.DTO;

public class GetBannerDto
{
    public Guid BannerId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public User Owner { get; set; }
    public Category Category { get; set; }
    public DateTime CreatedAt { get; set; }
    public string Image { get; set; }

    public static GetBannerDto FromBanner(Banner banner)
    {
        return new GetBannerDto()
        {
            BannerId = banner.BannerId.Value,
            Title = banner.Title.Value,
            Description = banner.Description.Value,
            CreatedAt = banner.CreatedAt,
            Image = banner.Image.Value,
            Category = banner.Category,
            Owner = banner.Owner
        };
    }
}
