using Domain.StronglyTypes;

namespace Domain.Models;

public class Event : Post<EventId>
{
    public TargetUsers? Targets { get; set; }
    public RegistrationInfo? RegistrationInfo { get; set; }
}
