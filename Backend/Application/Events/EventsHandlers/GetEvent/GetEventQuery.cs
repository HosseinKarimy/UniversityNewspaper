using Application.Events.DTOs;
using Domain.StronglyTypes;
using Helper.CQRS;
using Helper.HelperModels;

namespace Application.Events.EventsHandlers.GetEvents;

public record GetEventQuery(EventId EventId) : IQuery<GetEventResult>
{
    public ImportantHttpContextCarrier ContextCarrier { get; set; } = new();
}

public record GetEventResult(EventDto Event);