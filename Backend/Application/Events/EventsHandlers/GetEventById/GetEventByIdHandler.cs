using Application.Events.DTOs;
using Application.Events.EventsRepositories;
using Helper.CQRS;

namespace Application.Events.EventsHandlers.GetEvents;

public class GetEventByIdHandler(IEventsUnitOfWork eventsUnitOfWork) : IQueryHandler<GetEventByIdQuery, EventDto>
{
    public async Task<EventDto> Handle(GetEventByIdQuery request, CancellationToken cancellationToken)
    {
        var Event = await eventsUnitOfWork.EventsRepository.GetByIdAsync(request.EventId, cancellationToken) ?? throw new Exception("Event Not Found");
        int registeredUserCount = Event.Registrations!.Where(er => er.Status == Domain.Enums.RegistrationStatus.Approved).Count();
        var eventsDto = EventDto.FromEvent(Event, registeredUserCount);
        return eventsDto;
    }
}
