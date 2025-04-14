using Application.Events.EventsHandlers.GetEvents;
using Domain.StronglyTypes;
using Helper.CQRS;
using Helper.HelperModels;

namespace Application.Events.EventsHandlers.EventRegistered;

public record EventRegisteredQuery(UserId UserId) : IQuery<GetEventsResult>
{
    public ImportantHttpContextCarrier ContextCarrier { get; set; } = new();
}

