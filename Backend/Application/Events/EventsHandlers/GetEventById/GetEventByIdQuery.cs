using Application.Events.DTOs;
using Domain.StronglyTypes;
using Helper.CQRS;
using Helper.HelperModels;

namespace Application.Events.EventsHandlers.GetEvents;

public record GetEventByIdQuery(EventId EventId) : IQuery<EventDto>
{
    public ImportantHttpContextCarrier ContextCarrier { get; set; } = new();
}