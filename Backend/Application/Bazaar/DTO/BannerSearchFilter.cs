namespace Application.Bazaar.DTO;

public class BannerSearchFilter
{
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string? Title { get; set; }
    public Guid? CategoryId { get; set; }
    public int? OwnerId { get; set; }
}
