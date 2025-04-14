using Application.Events.DTOs;
using Application.Events.EventsHandlers.GetEvents;
using Application.Events.EventsRepositories;
using Helper.CQRS;

namespace Application.Events.EventsHandlers.GetMyEvents;

public class GetEventsCreatedByUserHandler(IEventsUnitOfWork eventsUnitOfWork) : IQueryHandler<GetEventsCreatedByUserQuery, GetEventsResult>
{
    public async Task<GetEventsResult> Handle(GetEventsCreatedByUserQuery request, CancellationToken cancellationToken)
    {
        var targetUser = request.UserId;
        var requestedUser = request.ContextCarrier.AuthenticatedUser.Id;
        Authorization();
        var Events = await eventsUnitOfWork.EventsRepository.GetEventsCreatedByUser(targetUser, cancellationToken);
        var eventsDto = Events.Select(e => EventDto.FromEvent(e)).ToList();
        return new GetEventsResult(eventsDto);

        void Authorization()
        {
            if (targetUser != requestedUser)
            {
                throw new Exception("UnAuthorized");
            }
        }
    }

}
