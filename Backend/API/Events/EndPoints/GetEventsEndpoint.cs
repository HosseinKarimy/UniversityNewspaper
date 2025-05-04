using Application.Events.DTOs;
using Application.Events.EventsHandlers.GetEvents;
using Carter;
using Helper.JsuServerResponse;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Events;

public class GetEventsEndpoint : CarterModule
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/Events", async ([FromBody]EventSearchFilter Filters, IMediator mediator) =>
        {
            var query = new GetEventsQuery(Filters);
            var result = await mediator.Send(query);
            return Results.Ok(JsuContractTemplate.GetContractTemplate("Success", result));
        }).DisableAntiforgery();
    }
}
