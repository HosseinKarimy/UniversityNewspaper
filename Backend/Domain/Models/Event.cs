using Domain.Enums;
using Domain.StronglyTypes;

namespace Domain.Models;

public class Event : Post<EventId>
{
    public DateTime? Date { get; set; }
    public string? ImageURl { get; set; }
    public string? Location { get; set; }
    public string? AdditionalInfoPairs { get; set; }
    public List<Department>? Organizers { get; set; }
    public TargetUsers? Targets { get; set; }
    public RegistrationInfo? RegistrationInfo { get; set; }

    public List<User>? RegisteredUsers { get; set; }
}
