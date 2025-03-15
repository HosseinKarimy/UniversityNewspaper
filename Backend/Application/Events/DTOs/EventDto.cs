using Domain.Enums;
using Domain.Models;

namespace Application.Events.DTOs;

public record EventDto(
    Guid EventId,
    string? Title,
    string? Description,
    int OwnerId,
    string? ImageUrl,
    string? Location,
    DateTime? Date,
    DateTime CreatedAt,
    List<Department>? Organizers,
    List<UserRole>? TargetsRole,
    List<TeachingGroup>? TargetsGroups,
    DateOnly? RegisterDeadline,
    int? RegisterCapacity,
    decimal? RegisterFee,
    PaymentType? PaymentType,
    int? RegisteredUsersCount)
{
    public static EventDto FromEvent(Event @event)
    {
        return new EventDto(@event.Id.Value , @event.Title, @event.Description,@event.OwnerId.Value , @event.ImageURl , @event.Location ,@event.Date , @event.CreatedAt,@event.Organizers, @event.Targets?.Roles,@event.Targets?.TargetGroups , @event.RegistrationInfo?.Deadline, @event.RegistrationInfo?.Capacity , @event.RegistrationInfo?.Fee, @event.RegistrationInfo?.PaymentType , @event.RegisteredUsers?.Count ?? 0);
    }
}
