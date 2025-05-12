using Application.Events.EventsHandlers.GetRegistrationByEventId;
using Carter;
using Helper.JsuServerResponse;
using MediatR;

namespace API.Events.EndPoints;

public class GetEventRegistrationByEventIdEndpoint : CarterModule
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/Events/Registration/{eventId:guid}", async (Guid eventId, IMediator mediator) =>
        {
            var query = new GetRegistrationByEventIdQuery(Domain.StronglyTypes.EventId.Of(eventId));
            var result = await mediator.Send(query);
            return Results.Ok(JsuContractTemplate.GetContractTemplate(true, result));
        }).DisableAntiforgery();
    }
}
