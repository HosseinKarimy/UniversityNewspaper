using Application.Events.DTOs;
using FluentValidation;
using Helper.CQRS;
using Helper.HelperModels;

namespace Application.Events.EventsHandlers.AddEvent;

public record AddEventCommand(AddOrUpdateEventDto EventDto) : ICommand<RequestResult<Guid>>
{
    public ImportantHttpContextCarrier ContextCarrier { get ; set; } = new();
}

public class AddEventValidation : AbstractValidator<AddEventCommand>
{
    public AddEventValidation()
    {
        RuleFor(p => p.EventDto.Title).NotEmpty().MinimumLength(2);
    }
}