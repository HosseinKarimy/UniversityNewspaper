using Domain.StronglyTypes;

namespace Domain.Models;

public class Post<TId>
{
    public TId Id { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public User Owner { get; set; }
    public UserId OwnerId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
