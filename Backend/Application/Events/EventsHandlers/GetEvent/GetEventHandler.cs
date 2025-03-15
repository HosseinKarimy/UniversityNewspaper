using Application.Events.DTOs;
using Application.Events.EventsRepositories;
using Helper.CQRS;

namespace Application.Events.EventsHandlers.GetEvents;

public class GetEventHandler(IEventsUnitOfWork eventsUnitOfWork) : IQueryHandler<GetEventQuery, GetEventResult>
{
    public async Task<GetEventResult> Handle(GetEventQuery request, CancellationToken cancellationToken)
    {
        var Event = await eventsUnitOfWork.EventsRepository.GetByIdAsync(request.EventId ,cancellationToken);
        //todo if requester == owner , load regestered user
        var eventsDto = EventDto.FromEvent(Event);
        return new GetEventResult(eventsDto);
    }
}
