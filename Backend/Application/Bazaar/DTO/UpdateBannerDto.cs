namespace Application.Bazaar.DTO;

public class UpdateBannerDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public Guid CategoryId { get; set; }
    public string Image { get; set; }
}
