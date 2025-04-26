using Domain.Enums;
using Domain.Models;

namespace Application.Events.DTOs
{
    public record AddOrUpdateEventDto(
        string Title,
        string? Description,
        string? AdditionalInfoPairs,
        DateTime Date,
        string ImageURl,
        string Location,
        List<Department> Organizers,
        DateTime? Deadline,
        int? Capacity,
        decimal? Fee,
        EventStatus Status);
}
