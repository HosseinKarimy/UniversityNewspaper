using Domain.Enums;

namespace API.Events.DTO;

public record EventDetailsDto(Guid EventId,
    string? Title,
    string? Description,
    string? AdditionalInfoPairs,
    int OwnerId,
    string? ImageUrl,
    string? Location,
    DateTime? Date,
    DateTime CreatedAt,
    List<string>? Organizers,
    List<string>? TargetsRole,
    List<string>? TargetsGroups,
    DateOnly? RegisterDeadline,
    int? RegisterCapacity,
    decimal? RegisterFee,
    PaymentType? PaymentType,
    int? RegisteredUsersCount,
    List<int> RegisteredUsers);