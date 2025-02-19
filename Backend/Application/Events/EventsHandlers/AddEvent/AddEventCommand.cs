using Application.Events.DTOs;
using Helper.CQRS;
using Helper.HelperModels;
using MediatR;

namespace Application.Events.EventsHandlers.AddEvent;

public record AddEventCommand(AddEventsDto EventDto) : ICommand<AddEventResult>
{
    public ImportantHttpContextCarrier ContextCarrier { get ; set; } = new();
}

public record AddEventResult(Guid EventId);
