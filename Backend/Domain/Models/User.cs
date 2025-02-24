using Domain.Enums;
using Domain.StronglyTypes;

namespace Domain.Models;

public class User
{
    public UserId Id { get; set; }
    public UserRole? Role { get; set; }
    public string? Username { get; set; }
    public TeachingGroup? Group { get; set; }
}
