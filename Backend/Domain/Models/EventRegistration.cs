using Domain.Enums;
using Domain.Exceptions;
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


    public void ChangeStatus(UserId actorId, RegistrationStatus newStatus)
    {
        var isEventOwner = actorId == Event.OwnerId;
        var isUser = actorId == User.Id;

        if (isUser && isEventOwner)
        {
            Status = newStatus;
            return;
        }

        if (isUser)
        {
            if (newStatus != RegistrationStatus.Pending && newStatus != RegistrationStatus.Cancelled)
                throw new BusinessRuleViolationException("Only User can request or cancel registration.");

            Status = newStatus;
            return;
        }

        if (isEventOwner)
        {
            if (newStatus == RegistrationStatus.Cancelled)
                throw new BusinessRuleViolationException("Only User can request or cancel registration.");

            if (Status == RegistrationStatus.Cancelled)
                throw new BusinessRuleViolationException("Registration is already cancelled.");

            Status = newStatus;
            return;
        }

        throw new BusinessRuleViolationException("Access Denied.");
    }

}
