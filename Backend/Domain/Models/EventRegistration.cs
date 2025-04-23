using Domain.Enums;
using Domain.StronglyTypes;

namespace Domain.Models;

public class EventRegistration
{
    public EventId EventId { get; set; }
    public Event Event { get; set; }

    public UserId UserId { get; set; }
    public User User { get; set; }

    public RegistrationStatus Status { get; set; } // Pending, Approved, Rejected, WaitingList, Cancelled
    public DateTime? RequestedAt { get; set; }
}
