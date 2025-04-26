using Domain.Enums;
using Domain.StronglyTypes;

namespace Domain.Models;

public class Event : Post<EventId>
{
    public DateTime? Date { get; set; }
    public string? Location { get; set; }
    public string? AdditionalInfoPairs { get; set; }
    public List<Department>? Organizers { get; set; }
    public DateTime? Deadline { get; set; }
    public int? Capacity { get; set; }
    public decimal? Fee { get; set; }
    public EventStatus EventStatus { get; set; }

    public List<EventRegistration>? Registrations { get; set; }
}
