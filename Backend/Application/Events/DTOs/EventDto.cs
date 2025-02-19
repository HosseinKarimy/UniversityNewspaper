using Domain.Enums;
using Domain.Models;

namespace Application.Events.DTOs;

public record EventDto(string? Title, string? Description, string? TargetsRole, DateOnly? RegisterDeadline, int? RegisterCapacity, decimal? RegisterFee, PaymentType? PaymentType)
{
    public static EventDto FromEvent(Event @event)
    {
        return new EventDto(@event.Title, @event.Description, @event.Targets?.Role, @event.RegistrationInfo?.Deadline, @event.RegistrationInfo?.Capacity , @event.RegistrationInfo?.Fee, @event.RegistrationInfo?.PaymentType);
    }
}
