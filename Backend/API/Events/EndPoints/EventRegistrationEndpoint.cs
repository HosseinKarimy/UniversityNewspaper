using API.Bazaar.EndPoints;
using Application.Events.EventsHandlers.EventRegistrations;
using Carter;
using Domain.Enums;
using Domain.StronglyTypes;
using Helper.JsuServerResponse;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Events.EndPoints;


public record EventRegistrationRequest(Guid EventId, int UserId , RegistrationStatus RegistrationStatus);

public class EventRegistrationEndpoint : CarterModule
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/Events/Registration", async ([FromBody] EventRegistrationRequest request, IMediator mediator) =>
        {
            //create Command
            var command = new EventRegistrationCommand(Domain.StronglyTypes.EventId.Of(request.EventId) , UserId.Of(request.UserId) , request.RegistrationStatus );

            //Send Command to Mediator Pipeline
            var result = await mediator.Send(command);

            return Results.Ok(JsuContractTemplate.GetContractTemplate("Success"));
        }).DisableAntiforgery();
    }
}
