using Domain.Enums;

namespace Domain.Models;

public class TargetUsers
{
    public List<UserRole>? Roles { get; set; }
    public List<TeachingGroup>? TargetGroups { get; set; }
}
