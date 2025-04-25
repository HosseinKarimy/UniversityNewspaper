using Application.Events.EventsHandlers.GetEvents;
using Carter;
using Helper.JsuServerResponse;
using MediatR;

namespace API.Events.EndPoints;

public class GetEventById : CarterModule
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/Events/{id:guid}", async (Guid id, IMediator mediator) =>
        {
            var query = new GetEventByIdQuery(Domain.StronglyTypes.EventId.Of(id));
            var result = await mediator.Send(query);
            return Results.Ok(JsuContractTemplate.GetContractTemplate("Success", result));
        }).DisableAntiforgery();
    }
}
