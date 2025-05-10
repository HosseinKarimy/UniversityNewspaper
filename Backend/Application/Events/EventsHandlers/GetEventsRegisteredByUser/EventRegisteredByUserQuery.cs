using Application.Events.DTOs;
using Domain.StronglyTypes;
using Helper.CQRS;
using Helper.HelperModels;

namespace Application.Events.EventsHandlers.EventRegistered;

public record EventRegisteredByUserQuery(UserId UserId) : IQuery<List<UserEventStatusDto>>
{
    public ImportantHttpContextCarrier ContextCarrier { get; set; } = new();
}

