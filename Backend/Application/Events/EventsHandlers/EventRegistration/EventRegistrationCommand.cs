using Domain.StronglyTypes;
using Helper.CQRS;
using Helper.HelperModels;

namespace Application.Events.EventsHandlers.EventRegistration;

public record EventRegistrationCommand(EventId EventId , UserId UserId , RegisterType RegisterType) : ICommand<EventRegistrationResult>
{
    public ImportantHttpContextCarrier ContextCarrier { get; set; } = new();
}

public record EventRegistrationResult();

public enum RegisterType
{
    Register,
    UnRegister
}
