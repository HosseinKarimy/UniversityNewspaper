using Application.Events.DTOs;
using Application.Events.EventsRepositories;
using Application.Exceptions;
using Helper.CQRS;

namespace Application.Events.EventsHandlers.EventRegistered;

public class EventRegisteredByUserHandler(IEventsUnitOfWork eventsUnitOfWork) : IQueryHandler<EventRegisteredByUserQuery, List<UserEventStatusDto>>
{
    public async Task<List<UserEventStatusDto>> Handle(EventRegisteredByUserQuery request, CancellationToken cancellationToken)
    {
        var targetUser = request.UserId;
        var requestedUser = request.ContextCarrier.AuthenticatedUser!.Id;
        Authorization();
        var Events = await eventsUnitOfWork.EventsRepository.GetEventsRegisteredByUser(targetUser, cancellationToken);
        var UserEventStatusDtos = Events.Select(e =>
        {
            int registeredUserCount = e.Registrations!.Where(er => er.Status == Domain.Enums.RegistrationStatus.Approved).Count();
            var eventDto = EventDto.FromEvent(e, registeredUserCount);
            var eventRegistrationDto = EventRegistrationDto.FromEventRegistration(e.Registrations!.Find(r => r.UserId == targetUser)!);
            return new UserEventStatusDto(eventDto, eventRegistrationDto);
        }).ToList();
        return UserEventStatusDtos;

        void Authorization()
        {
            if (targetUser != requestedUser)
            {
                throw new UnauthorizedExeption();
            }
        }
    }

}
