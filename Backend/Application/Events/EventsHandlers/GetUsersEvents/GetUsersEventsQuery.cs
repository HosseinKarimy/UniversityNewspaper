using Application.Events.DTOs;
using Domain.StronglyTypes;
using Helper.CQRS;
using Helper.HelperModels;

namespace Application.Events.EventsHandlers.GetMyEvents;

public record GetUsersEventsQuery(UserId UserId) : IQuery<GetUserEventsResult>
{
    public ImportantHttpContextCarrier ContextCarrier { get; set; } = new();
}

public record GetUserEventsResult(List<EventDto> Events);