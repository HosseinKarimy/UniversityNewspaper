using Domain.Models;

namespace Application.Events.DTOs;

public record EventRegistrationDto(
    Guid EventId,
    int UserId,
    int Status,
    DateTime? RequestedAt)
{
    public static EventRegistrationDto FromEventRegistration(EventRegistration registration)
    {
        return new EventRegistrationDto(registration.EventId.Value, registration.UserId.Value, (int)registration.Status, registration.RequestedAt);
    }

}
