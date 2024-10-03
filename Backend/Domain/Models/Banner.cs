using Domain.StronglyTypes;

namespace Domain.Models;

public class Banner
{
    public BannerId BannerId { get; set; }
    public Title Title { get; set; }
    public Description Description { get; set; }
    public User Owner { get; set; }
    public UserId OwnerId { get; set; }
    public Category Category { get; set; }
    public CategoryId CategoryId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public List<ImageURL> Images { get; set; }
}
