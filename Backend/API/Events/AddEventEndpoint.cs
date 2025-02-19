using Application.Events.DTOs;
using Application.Events.EventsHandlers.AddEvent;
using Carter;
using Domain.Enums;
using Helper.JsuServerResponse;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Events;

public record AddEventsRequest(string Title)
{
    public string? Description { get; set; } = null;
    public string? TargetsRole { get; set; } = null;
    public DateOnly? RegisterDeadline { get; set; } = null;
    public int? RegisterCapacity { get; set; } = null;
    public decimal? RegisterFee { get; set; } = null;
    public PaymentType? PaymentType { get; set; } = null;
}

public class AddEventEndpoint : CarterModule
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/Events", async ([FromForm] AddEventsRequest request, IMediator mediator) =>
        {
            var addEventDto = request.Adapt<AddEventsDto>();

            var command = new AddEventCommand(addEventDto);

            var result = await mediator.Send(command);

            return Results.Ok(JsuContractTemplate.GetContractTemplate("Success", result));
        }).DisableAntiforgery();
    }
}
