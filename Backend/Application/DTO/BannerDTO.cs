using Domain.Models;

namespace Application.DTO;

public class BannerDTO
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int OwnerId { get; set; }
    public int CategoryId { get; set; }
    public List<string> Images { get; set; }   

    public Banner ToBanner()
    {
        //TODO - implement Banner To BannerDto
        return new Banner();
    }
}
