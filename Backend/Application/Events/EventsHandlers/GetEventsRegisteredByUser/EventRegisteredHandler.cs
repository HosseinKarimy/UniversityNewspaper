using Application.Events.DTOs;
using Application.Events.EventsHandlers.GetEvents;
using Application.Events.EventsRepositories;
using Helper.CQRS;

namespace Application.Events.EventsHandlers.EventRegistered;

public class EventRegisteredHandler(IEventsUnitOfWork eventsUnitOfWork) : IQueryHandler<EventRegisteredQuery, GetEventsResult>
{
    public async Task<GetEventsResult> Handle(EventRegisteredQuery request, CancellationToken cancellationToken)
    {
        Authorization();
        var Events = await eventsUnitOfWork.EventsRepository.GetEventsRegisteredByUser(request.UserId, cancellationToken);
        var eventsDto = Events.Select(e =>
        {
            int registeredUserCount = e.Registrations!.Where(er => er.Status == Domain.Enums.RegistrationStatus.Approved).Count();
            return EventDto.FromEvent(e, registeredUserCount);
        }).ToList();
        return new GetEventsResult(eventsDto);

        void Authorization()
        {
            if (request.UserId != request.ContextCarrier.AuthenticatedUser!.Id)
                throw new Exception("Unauthorized");
        }
    }

}
