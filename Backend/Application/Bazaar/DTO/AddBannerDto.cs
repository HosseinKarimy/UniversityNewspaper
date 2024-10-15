using Domain.Models;

namespace Application.Bazaar.DTO;

public class AddBannerDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public Guid CategoryId { get; set; }
    public string Image { get; set; }
    public decimal Price { get; set; }
}
