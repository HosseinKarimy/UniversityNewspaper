using Application.Events.DTOs;
using Helper.CQRS;
using Helper.HelperModels;
using MediatR;

namespace Application.Events.EventsHandlers.AddEvent;

public record AddEventCommand(AddOrUpdateEventDto EventDto) : ICommand<RequestResult<Guid>>
{
    public ImportantHttpContextCarrier ContextCarrier { get ; set; } = new();
}

