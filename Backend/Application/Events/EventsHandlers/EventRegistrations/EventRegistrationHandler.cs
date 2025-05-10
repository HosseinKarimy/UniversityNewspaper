using Application.Events.EventsRepositories;
using Application.Exceptions;
using Domain.Enums;
using Domain.Models;
using Helper.CQRS;
using MediatR;

namespace Application.Events.EventsHandlers.EventRegistrations;

public class EventRegistrationHandler(IEventsUnitOfWork eventsUnitOfWork)
    : ICommandHandler<EventRegistrationCommand, Unit>
{
    public async Task<Unit> Handle(EventRegistrationCommand request, CancellationToken cancellationToken)
    {
        var userId = request.UserId;
        var eventId = request.EventId;
        var status = request.RegisterStatus;
        var actorId = request.ContextCarrier.AuthenticatedUser!.Id;

        var targetEvent = await eventsUnitOfWork.EventsRepository
            .GetByIdAsync(eventId, cancellationToken)
            ?? throw new NotFoundException();

        var registration = await eventsUnitOfWork.EventRegisterationRepository
            .GetByIdAsync((eventId, userId), cancellationToken);

        if (registration is null)
        {
            if (targetEvent.EventStatus != EventStatus.RegistrationOpen)
                throw new BadRequestException("Registration is closed");

            if (actorId != userId)
                throw new AccessDeniedExcepion("Only the user can register themselves");

            if (status != RegistrationStatus.Pending)
                throw new BadRequestException("Invalid registration status for new request");

            registration = new EventRegistration
            {
                EventId = eventId,
                UserId = userId,
                Status = RegistrationStatus.Pending,
                RequestedAt = DateTime.UtcNow,
            };

            await eventsUnitOfWork.EventRegisterationRepository.AddAsync(registration, cancellationToken);
        } else
        {
            registration.ChangeStatus(actorId, status);
            eventsUnitOfWork.EventRegisterationRepository.Update(registration);
        }

        await eventsUnitOfWork.SaveChangesAsync(cancellationToken);
        return new Unit();
    }
}

