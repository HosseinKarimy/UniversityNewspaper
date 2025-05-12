using Application.Events.DTOs;
using Application.Events.EventsHandlers.AddEvent;
using Carter;
using Domain.Enums;
using Helper.JsuServerResponse;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Events.EndPoints;

public record AddOrUpdateEventRequest(string Title)
{
    public string? Description { get; set; } = null;
    public string? AdditionalInfoPairs { get; set; } = null;
    public DateTime? Date { get; set; } = null;
    public IFormFile? Image { get; set; } = null;
    public string? Location { get; set; } = null;
    public string? Organizers { get; set; } = null;
    public DateTime? RegisterDeadline { get; set; } = null;
    public int? RegisterCapacity { get; set; } = null;
    public decimal? RegisterFee { get; set; } = null;
    public EventStatus Status { get; set; }
}

public class AddEventEndpoint : CarterModule
{
    public AddEventEndpoint() : base("/Events")
    {
        
    }
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/", async ([FromForm] AddOrUpdateEventRequest request, IMediator mediator) =>
        {
            var addEventDto = request.Adapt<AddOrUpdateEventDto>();

            var command = new AddEventCommand(addEventDto);

            var result = await mediator.Send(command);

            return Results.Ok(JsuContractTemplate.FromRequestResult(result));
        }).DisableAntiforgery();
    }
}
