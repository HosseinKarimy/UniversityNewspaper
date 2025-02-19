using Application.Events.DTOs;
using Helper.CQRS;
using Helper.HelperModels;

namespace Application.Events.EventsHandlers.GetEvents;

public record GetEventsQuery : IQuery<GetEventsResult>
{
    public ImportantHttpContextCarrier ContextCarrier { get; set; } = new();
}

public record GetEventsResult(List<EventDto> Events);