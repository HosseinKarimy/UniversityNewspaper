using Application.Events.DTOs;
using Application.Events.EventsRepositories;
using Helper.CQRS;

namespace Application.Events.EventsHandlers.GetRegistrationByEventId;

public class GetRegistrationByEventIdHandler(IEventsUnitOfWork eventsUnitOfWork) : IQueryHandler<GetRegistrationByEventIdQuery, GetRegistrationResult>
{
    public async Task<GetRegistrationResult> Handle(GetRegistrationByEventIdQuery request, CancellationToken cancellationToken)
    {
        var eventId = request.EventId;
        var actorId = request.ContextCarrier.AuthenticatedUser!.Id;
        var targetEvent = await eventsUnitOfWork.EventsRepository
            .GetByIdAsync(eventId, cancellationToken)
            ?? throw new Exception("Event not found");

        if (targetEvent.OwnerId != actorId)
            throw new UnauthorizedAccessException("Only the event owner can view registrations");

        var registrations = await eventsUnitOfWork.EventRegisterationRepository.GetRegistrationsOfEvent(eventId, cancellationToken);
        var registrationDtos = registrations.Select(r=>EventRegistrationDto.FromEventRegistration(r)).ToList();
        return new GetRegistrationResult(registrationDtos);
    }
}
