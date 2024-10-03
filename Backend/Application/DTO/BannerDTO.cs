using Domain.Models;
using Domain.StronglyTypes;

namespace Application.DTO;

public class BannerDTO
{
    public Guid bannerId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public Guid OwnerId { get; set; }
    public Guid CategoryId { get; set; }
    public List<string> Images { get; set; }   

    public Banner ToBanner()
    {
        //TODO - implement Banner To BannerDto
        return new Banner()
        {
            BannerId = new BannerId(bannerId),
            CategoryId = new CategoryId(CategoryId),
            OwnerId = new UserId(OwnerId),
            CreatedAt = DateTime.Now,
            Description = new Description(Description),
            Title = new Title(Title),
            Images = Images.Select(image => new ImageURL(image)).ToList()
        };
    }
}
