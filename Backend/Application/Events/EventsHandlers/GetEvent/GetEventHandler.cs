using Application.Events.DTOs;
using Application.Events.EventsRepositories;
using Helper.CQRS;

namespace Application.Events.EventsHandlers.GetEvents;

public class GetEventHandler(IEventsUnitOfWork eventsUnitOfWork) : IQueryHandler<GetEventQuery, GetEventResult>
{
    public async Task<GetEventResult> Handle(GetEventQuery request, CancellationToken cancellationToken)
    {
        var Event = await eventsUnitOfWork.EventsRepository.GetByIdAsync(request.EventId, cancellationToken);
        int registeredUserCount = Event.RegisteredUsers?.Count ?? 0;
        if (request.ContextCarrier.AuthenticatedUser.Id != Event.OwnerId)
            Event.RegisteredUsers = null;
        var eventsDto = EventDto.FromEvent(Event, registeredUserCount);
        return new GetEventResult(eventsDto);
    }
}
