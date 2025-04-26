using Application.Events.DTOs;
using Domain.StronglyTypes;
using Helper.CQRS;
using Helper.HelperModels;
using MediatR;

namespace Application.Events.EventsHandlers.UpdateEvent;

public record UpdateEventCommand(EventId EventId,AddOrUpdateEventDto EventDto) : ICommand<Unit>
{
    public ImportantHttpContextCarrier ContextCarrier { get; set; } = new();
}
