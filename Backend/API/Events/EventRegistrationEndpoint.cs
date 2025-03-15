using API.Bazaar.EndPoints;
using Application.Events.EventsHandlers.EventRegistration;
using Carter;
using Helper.JsuServerResponse;
using MediatR;

namespace API.Events;

public class EventRegistrationEndpoint : CarterModule
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/Events/Register/{id:Guid}", async (Guid id, IMediator mediator) =>
        {
            //create Command
            var command = new EventRegistrationCommand(Domain.StronglyTypes.EventId.Of(id));

            //Send Command to Mediator Pipeline
            var result = await mediator.Send(command);

            return Results.Ok(JsuContractTemplate.GetContractTemplate("Success"));
        }).DisableAntiforgery();
    }
}
