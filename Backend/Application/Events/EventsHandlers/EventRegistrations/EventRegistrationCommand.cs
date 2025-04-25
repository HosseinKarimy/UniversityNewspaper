using Domain.Enums;
using Domain.StronglyTypes;
using Helper.CQRS;
using Helper.HelperModels;
using MediatR;

namespace Application.Events.EventsHandlers.EventRegistrations;

public record EventRegistrationCommand(EventId EventId , UserId UserId , RegistrationStatus RegisterStatus) : ICommand<Unit>
{
    public ImportantHttpContextCarrier ContextCarrier { get; set; } = new();
}
