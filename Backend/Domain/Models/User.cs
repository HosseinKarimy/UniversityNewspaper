using Domain.StronglyTypes;

namespace Domain.Models;

public class User
{
    public UserId UserId { get; set; }
    public FullName FullName { get; set; }
}
