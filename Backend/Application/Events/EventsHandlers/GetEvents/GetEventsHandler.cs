using Application.Events.DTOs;
using Application.Events.EventsRepositories;
using Helper.CQRS;

namespace Application.Events.EventsHandlers.GetEvents;

public class GetEventsHandler(IEventsUnitOfWork eventsUnitOfWork) : IQueryHandler<GetEventsQuery, GetEventsResult>
{
    public async Task<GetEventsResult> Handle(GetEventsQuery request, CancellationToken cancellationToken)
    {
        var Events = await eventsUnitOfWork.EventsRepository.GetAllAsync(cancellationToken);
        var eventsDto = Events.Select(e =>
        {
            int registeredUserCount = e.Registrations!.Where(er=>er.Status == Domain.Enums.RegistrationStatus.Approved).Count();
            return EventDto.FromEvent(e, registeredUserCount);
        }).ToList();
        return new GetEventsResult(eventsDto);
    }
}
