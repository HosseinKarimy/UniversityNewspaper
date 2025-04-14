using API.Bazaar.EndPoints;
using Application.Events.EventsHandlers.EventRegistration;
using Carter;
using Domain.StronglyTypes;
using Helper.JsuServerResponse;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Events.EndPoints;


public record EventRegistrationRequest(Guid EventId, int UserId);

public class EventRegistrationEndpoint : CarterModule
{
    public EventRegistrationEndpoint() : base("/Events")
    {
        
    }

    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/Register", async ([FromBody] EventRegistrationRequest request, IMediator mediator) =>
        {
            //create Command
            var command = new EventRegistrationCommand(Domain.StronglyTypes.EventId.Of(request.EventId) , UserId.Of(request.UserId) , RegisterType.Register);

            //Send Command to Mediator Pipeline
            var result = await mediator.Send(command);

            return Results.Ok(JsuContractTemplate.GetContractTemplate("Success"));
        }).DisableAntiforgery();

        app.MapPost("/UnRegister", async ([FromBody] EventRegistrationRequest request, IMediator mediator) =>
        {
            //create Command
            var command = new EventRegistrationCommand(Domain.StronglyTypes.EventId.Of(request.EventId), UserId.Of(request.UserId), RegisterType.UnRegister);

            //Send Command to Mediator Pipeline
            var result = await mediator.Send(command);

            return Results.Ok(JsuContractTemplate.GetContractTemplate("Success"));
        }).DisableAntiforgery();
    }
}
