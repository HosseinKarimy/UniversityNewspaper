using Application.Events.EventsRepositories;
using Application.Exceptions;
using Helper.CQRS;
using MediatR;

namespace Application.Events.EventsHandlers.UpdateEvent;

public class UpdateEventHandler(IEventsUnitOfWork eventsUnitOfWork) : ICommandHandler<UpdateEventCommand, Unit>
{
    public async Task<Unit> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
    {
        var targetEvent = await eventsUnitOfWork.EventsRepository.GetByIdAsync(request.EventId, cancellationToken) ?? throw new Exception("Event Not Found");

        var userId = request.ContextCarrier.AuthenticatedUser!.Id;

        if (userId != targetEvent.OwnerId)
            throw new UnauthorizedExeption();

        UpdateEventObject();
        await eventsUnitOfWork.SaveChangesAsync(cancellationToken);
        return new Unit();

        void UpdateEventObject()
        {
            var eventDto = request.EventDto;
            targetEvent.Id = request.EventId;
            targetEvent.Title = eventDto.Title;
            targetEvent.Description = eventDto.Description;
            targetEvent.AdditionalInfoPairs = eventDto.AdditionalInfoPairs;
            targetEvent.Date = eventDto.Date;
            targetEvent.ImageUrl = eventDto.ImageURl;
            targetEvent.Location = eventDto.Location;
            targetEvent.Organizers = eventDto.Organizers;
            targetEvent.CreatedAt = DateTime.Now;
            targetEvent.Deadline = eventDto.Deadline;
            targetEvent.Capacity = eventDto.Capacity;
            targetEvent.Fee = eventDto.Fee;
            targetEvent.EventStatus = eventDto.Status;
        }
    }
}
