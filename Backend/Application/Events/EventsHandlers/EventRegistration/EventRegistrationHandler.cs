using Application.Bazaar.BazzarRepositories;
using Application.Events.EventsRepositories;
using Helper.CQRS;

namespace Application.Events.EventsHandlers.EventRegistration;

public class EventRegistrationHandler(IEventsUnitOfWork eventsUnitOfWork , IUserRepository userRepo) : ICommandHandler<EventRegistrationCommand, EventRegistrationResult>
{
    public async Task<EventRegistrationResult> Handle(EventRegistrationCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepo.GetByIdAsync(request.ContextCarrier.AuthenticatedUser.Id, cancellationToken);
        var eventEntity = await eventsUnitOfWork.EventsRepository.GetByIdAsync(request.EventId, cancellationToken);

        if (user != null && eventEntity != null && !eventEntity.RegisteredUsers.Any(u => u.Id == user.Id))
        {
            eventEntity.RegisteredUsers.Add(user);
            await eventsUnitOfWork.SaveChangesAsync(cancellationToken);
        }
        return new EventRegistrationResult();
    }
}
