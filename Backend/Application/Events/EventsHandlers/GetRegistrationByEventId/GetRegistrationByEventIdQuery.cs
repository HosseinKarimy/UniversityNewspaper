using Application.Events.DTOs;
using Domain.StronglyTypes;
using Helper.CQRS;
using Helper.HelperModels;

namespace Application.Events.EventsHandlers.GetRegistrationByEventId;

public record GetRegistrationByEventIdQuery(EventId EventId) : IQuery<GetRegistrationResult>
{
    public ImportantHttpContextCarrier ContextCarrier { get; set; } = new();
}

public record GetRegistrationResult(List<EventRegistrationDto> Registrations);