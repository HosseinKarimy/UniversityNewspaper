using Application.Events.EventsHandlers.GetEvents;
using Carter;
using Helper.JsuServerResponse;
using MediatR;

namespace API.Events;

public class GetEventsEndpoint : CarterModule
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/Events", async (IMediator mediator) =>
        {
            var query = new GetEventsQuery();
            var result = await mediator.Send(query);
            return Results.Ok(JsuContractTemplate.GetContractTemplate("Success", result));
        }).DisableAntiforgery();
    }
}
