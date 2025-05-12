using Application.Events.DTOs;
using Domain.StronglyTypes;
using FluentValidation;
using Helper.CQRS;
using Helper.HelperModels;
using MediatR;

namespace Application.Events.EventsHandlers.UpdateEvent;

public record UpdateEventCommand(EventId EventId,AddOrUpdateEventDto EventDto) : ICommand<Unit>
{
    public ImportantHttpContextCarrier ContextCarrier { get; set; } = new();
}

public class AddEventValidation : AbstractValidator<UpdateEventCommand>
{
    public AddEventValidation()
    {
        RuleFor(p => p.EventDto.Title).NotEmpty().MinimumLength(2);
    }
}