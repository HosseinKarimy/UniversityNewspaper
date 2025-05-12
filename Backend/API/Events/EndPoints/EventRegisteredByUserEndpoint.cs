using Application.Events.EventsHandlers.EventRegistered;
using Carter;
using Domain.StronglyTypes;
using Helper.JsuServerResponse;
using MediatR;

namespace API.Events.EndPoints;

public class EventRegisteredByUserEndpoint : CarterModule
{

    public EventRegisteredByUserEndpoint() : base("/Events")
    {
        
    }

    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        //Events in which the user has registered
        app.MapGet("/Registered/{userId:int}", async (int userId, IMediator mediator) =>
        {
            //create Command
            var command = new EventRegisteredByUserQuery(UserId.Of(userId));

            //Send Command to Mediator Pipeline
            var result = await mediator.Send(command);
            
            return Results.Ok(JsuContractTemplate.GetContractTemplate(true, result));
        }).DisableAntiforgery();
    }
}
