using Application.Events.EventsHandlers.GetEvents;
using Domain.StronglyTypes;
using Helper.CQRS;
using Helper.HelperModels;

namespace Application.Events.EventsHandlers.GetMyEvents;

public record GetEventsCreatedByUserQuery(UserId UserId) : IQuery<GetEventsResult>
{
    public ImportantHttpContextCarrier ContextCarrier { get; set; } = new();
}