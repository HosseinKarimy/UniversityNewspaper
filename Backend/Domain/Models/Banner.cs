namespace Domain.Models;

public class Banner
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public User Owner { get; set; }
    public Category Category { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public List<ImageURL> Images { get; set; }
}
