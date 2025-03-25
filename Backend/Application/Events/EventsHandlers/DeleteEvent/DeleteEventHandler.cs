using Application.Events.EventsRepositories;
using Helper.CQRS;
using System.Net;

namespace Application.Events.EventsHandlers.DeleteEvent;

public class DeleteEventHandler(IEventsUnitOfWork eventsUnitOfWork) : ICommandHandler<DeleteEventCommand, DeleteEventResult>
{
    public async Task<DeleteEventResult> Handle(DeleteEventCommand request, CancellationToken cancellationToken)
    {
        var _event = await eventsUnitOfWork.EventsRepository.GetByIdAsync(request.EventId, cancellationToken);
        Authorization();
        eventsUnitOfWork.EventsRepository.Delete(_event!);
        await eventsUnitOfWork.SaveChangesAsync(cancellationToken);
        return new DeleteEventResult();

        void Authorization()
        {
            if(_event is null)
                throw new Exception("Event not found");
            else if(_event.OwnerId != request.ContextCarrier.AuthenticatedUser!.Id)
                throw new Exception("Unauthorized");
        }
    }

}
