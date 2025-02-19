using Domain.Enums;

namespace Application.Events.DTOs
{
    public record AddEventsDto(string Title, string? Description, TargetUsersDto? Targets, RegistrationInfoDto? RegistrationInfo);
    public record TargetUsersDto(string? Role);
    public record RegistrationInfoDto(DateOnly? Deadline, int? Capacity, decimal? Fee, PaymentType? PaymentType);
}
