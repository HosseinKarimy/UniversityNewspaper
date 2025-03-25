using Domain.StronglyTypes;
using Helper.CQRS;
using Helper.HelperModels;

namespace Application.Events.EventsHandlers.DeleteEvent;

public record DeleteEventCommand(EventId EventId) : ICommand<DeleteEventResult>
{
    public ImportantHttpContextCarrier ContextCarrier { get; set; } = new();
}

public record DeleteEventResult();
