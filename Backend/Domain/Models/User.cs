using Domain.StronglyTypes;

namespace Domain.Models;

public class User
{
    public UserId Id { get; set; }
    public string? Username { get; set; }
    public bool CanAddBanner { get; set; }
    public bool CanAddEvent { get; set; }
}
