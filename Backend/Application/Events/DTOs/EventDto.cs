using Domain.Enums;
using Domain.Models;

namespace Application.Events.DTOs;

public record EventDto(
    Guid EventId,
    string? Title,
    string? Description,
    string? AdditionalInfoPairs,
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
    List<int> RegisteredUsers,
    int? RegisteredUsersCount)
{
    public static EventDto FromEvent(Event @event , int? registeredUsers = 0)
    {
        return new EventDto(
            EventId: @event.Id.Value,
            Title: @event.Title,
            Description: @event.Description,
            AdditionalInfoPairs: @event.AdditionalInfoPairs,
            OwnerId: @event.OwnerId.Value,
            ImageUrl: @event.ImageURl,
            Location: @event.Location,
            Date: @event.Date,
            CreatedAt: @event.CreatedAt,
            Organizers: @event.Organizers,
            TargetsRole: @event.Targets?.Roles,
            TargetsGroups: @event.Targets?.TargetGroups,
            RegisterDeadline: @event.RegistrationInfo?.Deadline,
            RegisterCapacity: @event.RegistrationInfo?.Capacity,
            RegisterFee: @event.RegistrationInfo?.Fee,
            PaymentType: @event.RegistrationInfo?.PaymentType,
            RegisteredUsers: @event.RegisteredUsers?.Select(u => u.Id.Value).ToList() ?? [],
            RegisteredUsersCount: registeredUsers);
    }
}
