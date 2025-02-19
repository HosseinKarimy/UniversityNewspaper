using Domain.StronglyTypes;

namespace Domain.Models;

public class User
{
    public UserId Id { get; set; }
    public string Role { get; set; }
}
