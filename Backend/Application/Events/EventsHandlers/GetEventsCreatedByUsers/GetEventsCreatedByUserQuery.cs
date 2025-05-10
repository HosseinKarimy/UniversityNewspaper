using Application.Events.DTOs;
using Domain.StronglyTypes;
using Helper.CQRS;
using Helper.HelperModels;

namespace Application.Events.EventsHandlers.GetMyEvents;

public record GetEventsCreatedByUserQuery(UserId UserId) : IQuery<List<EventDto>>
{
    public ImportantHttpContextCarrier ContextCarrier { get; set; } = new();
}