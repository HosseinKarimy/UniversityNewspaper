using Application.Bazaar.BazzarRepositories;
using Application.Events.EventsRepositories;
using Helper.CQRS;
using System.Xml;

namespace Application.Events.EventsHandlers.EventRegistration;

public class EventRegistrationHandler(IEventsUnitOfWork eventsUnitOfWork, IUserRepository userRepo) : ICommandHandler<EventRegistrationCommand, EventRegistrationResult>
{
    public async Task<EventRegistrationResult> Handle(EventRegistrationCommand request, CancellationToken cancellationToken)
    {
        Authentication();

        var user = await userRepo.GetByIdAsync(request.ContextCarrier.AuthenticatedUser.Id, cancellationToken);
        var eventEntity = await eventsUnitOfWork.EventsRepository.GetByIdAsync(request.EventId, cancellationToken);

        if (user != null && eventEntity != null)
        {
            switch (request.RegisterType)
            {
                case RegisterType.Register:
                    eventEntity.RegisteredUsers.Add(user);
                    break;
                case RegisterType.UnRegister:
                    eventEntity.RegisteredUsers.Remove(user);
                    break;  
            }
            await eventsUnitOfWork.SaveChangesAsync(cancellationToken);
        }
        return new EventRegistrationResult();

        void Authentication()
        {
            if (request.ContextCarrier.AuthenticatedUser.Id != request.UserId)
                throw new Exception("UnAuthorized"); // TODO: Create Custom Exception for this case
        }
    }


}
