using Domain.Enums;

namespace Application.Events.DTOs
{
    public record AddEventsDto(string Title, string? Description, string? AdditionalInfoPairs, DateTime Date , string ImageURl , string Location, List<Department> Organizers, TargetUsersDto? Targets, RegistrationInfoDto? RegistrationInfo);
    public record TargetUsersDto(List<UserRole>? TargetsRoles , List<TeachingGroup>? TargetGroups);
    public record RegistrationInfoDto(DateOnly? Deadline, int? Capacity, decimal? Fee, PaymentType? PaymentType);
}
