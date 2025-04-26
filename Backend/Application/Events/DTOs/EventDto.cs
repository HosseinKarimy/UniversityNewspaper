using Domain.Enums;
using Domain.Models;

namespace Application.Events.DTOs;

public record EventDto(
    Guid EventId,
    string? Title,
    string? Description,
    string? AdditionalInfoPairs,
    EventStatus EventStatus,
    int OwnerId,
    string? ImageUrl,
    string? Location,
    DateTime? Date,
    DateTime CreatedAt,
    List<Department>? Organizers,
    DateTime? RegisterDeadline,
    int? RegisterCapacity,
    decimal? RegisterFee,
    int? RegisteredUsersCount)
{
    public static EventDto FromEvent(Event @event , int? registeredUsers = 0)
    {
        return new EventDto(
            EventId: @event.Id.Value,
            Title: @event.Title,
            Description: @event.Description,
            AdditionalInfoPairs: @event.AdditionalInfoPairs,
            EventStatus: @event.EventStatus,
            OwnerId: @event.OwnerId.Value,
            ImageUrl: @event.ImageUrl,
            Location: @event.Location,
            Date: @event.Date,
            CreatedAt: @event.CreatedAt,
            Organizers: @event.Organizers,
            RegisterDeadline: @event.Deadline,
            RegisterCapacity: @event.Capacity,
            RegisterFee: @event.Fee,
            RegisteredUsersCount: registeredUsers);
    }
}
