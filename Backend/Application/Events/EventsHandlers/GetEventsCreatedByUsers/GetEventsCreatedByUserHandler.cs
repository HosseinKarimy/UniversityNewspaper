using Application.Events.DTOs;
using Application.Events.EventsRepositories;
using Application.Exceptions;
using Helper.CQRS;

namespace Application.Events.EventsHandlers.GetMyEvents;

public class GetEventsCreatedByUserHandler(IEventsUnitOfWork eventsUnitOfWork) : IQueryHandler<GetEventsCreatedByUserQuery, List<EventDto>>
{
    public async Task<List<EventDto>> Handle(GetEventsCreatedByUserQuery request, CancellationToken cancellationToken)
    {
        var targetUser = request.UserId;
        var requestedUser = request.ContextCarrier.AuthenticatedUser!.Id;
        Authorization();
        var Events = await eventsUnitOfWork.EventsRepository.GetEventsCreatedByUser(targetUser, cancellationToken);
        var eventsDto = Events.Select(e =>
        {
            int registeredUserCount = e.Registrations!.Where(er => er.Status == Domain.Enums.RegistrationStatus.Approved).Count();
            return EventDto.FromEvent(e, registeredUserCount);
        }).ToList();
        return eventsDto;

        void Authorization()
        {
            if (targetUser != requestedUser)
            {
                throw new UnauthorizedExeption();
            }
        }
    }

}
