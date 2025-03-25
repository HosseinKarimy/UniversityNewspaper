using Application.Events.DTOs;
using Application.Events.EventsRepositories;
using Helper.CQRS;

namespace Application.Events.EventsHandlers.GetMyEvents;

public class GetMyEventsHandler(IEventsUnitOfWork eventsUnitOfWork) : IQueryHandler<GetUserEventsQuery, GetUserEventsResult>
{
    public async Task<GetUserEventsResult> Handle(GetUserEventsQuery request, CancellationToken cancellationToken)
    {
        var targetUser = request.UserId;
        var requestedUser = request.ContextCarrier.AuthenticatedUser.Id;
        Authorization();
        var Events = await eventsUnitOfWork.EventsRepository.GetByUserId(targetUser, cancellationToken);
        var eventsDto = Events.Select(e => EventDto.FromEvent(e)).ToList();
        return new GetUserEventsResult(eventsDto);

        void Authorization()
        {
            if (targetUser != requestedUser)
            {
                throw new Exception("UnAuthorized");
            }
        }
    }

}
