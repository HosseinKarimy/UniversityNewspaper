using Domain.Enums;
using Domain.StronglyTypes;

namespace Domain.Models;

public abstract class Banner
{
    public BannerId BannerId { get; set; }
    public Title Title { get; set; }
    public Description Description { get; set; }
    public User Owner { get; set; }
    public UserId OwnerId { get; set; }
    public Category Category { get; set; }
    public CategoryId CategoryId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public ImageURL? Image { get; set; }
    public List<Tag> Tags { get; set; }

    //Banner Status: You might want to add a property to indicate the status of a banner (e.g., "Active", "Inactive", "Pending Approval").

    //Banner Expiration: If banners have a limited lifespan, consider adding a property to track their expiration date.

    //Banner Views and Clicks: To track banner performance, you could add properties to store the number of views and clicks.

    //TargetAudience: A property to specify the intended audience for the banner (e.g., "Students", "Faculty", "Alumni").

}
