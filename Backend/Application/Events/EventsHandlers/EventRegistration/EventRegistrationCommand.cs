using Application.Events.DTOs;
using Domain.StronglyTypes;
using Helper.CQRS;
using Helper.HelperModels;

namespace Application.Events.EventsHandlers.EventRegistration;

public record EventRegistrationCommand(EventId EventId) : ICommand<EventRegistrationResult>
{
    public ImportantHttpContextCarrier ContextCarrier { get; set; } = new();
}

public record EventRegistrationResult();
