using Application.Events.DTOs;
using Application.Events.EventsRepositories;
using Helper.CQRS;

namespace Application.Events.EventsHandlers.GetEvents;

public class GetEventsHandler(IEventsUnitOfWork eventsUnitOfWork) : IQueryHandler<GetEventsQuery, PaginatedResult<EventDto>>
{
    public async Task<PaginatedResult<EventDto>> Handle(GetEventsQuery request, CancellationToken cancellationToken)
    {
        var Events = await eventsUnitOfWork.EventsRepository.GetFilteredEvents(request.SearchFilter,cancellationToken);
        var eventsDto = Events.Select(e =>
        {
            int registeredUserCount = e.Registrations?.Where(er=>er.Status == Domain.Enums.RegistrationStatus.Approved).Count() ?? 0;
            return EventDto.FromEvent(e, registeredUserCount);
        }).ToList();
        return new PaginatedResult<EventDto>(eventsDto,request.SearchFilter.Page,request.SearchFilter.PageSize);
    }
}
