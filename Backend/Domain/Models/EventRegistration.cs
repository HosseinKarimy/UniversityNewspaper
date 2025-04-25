using Domain.Enums;
using Domain.Models;
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
                throw new Exception("User can only request or cancel registration.");

            Status = newStatus;
            return;
        }

        if (isEventOwner)
        {
            if (newStatus == RegistrationStatus.Cancelled)
                throw new Exception("Only the user can cancel registration.");

            if (Status == RegistrationStatus.Cancelled)
                throw new Exception("Registration is already cancelled.");

            Status = newStatus;
            return;
        }

        throw new Exception("Access Denied.");
    }

}
