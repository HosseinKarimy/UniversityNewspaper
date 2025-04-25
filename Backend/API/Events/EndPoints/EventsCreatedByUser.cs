using Application.Events.EventsHandlers.GetMyEvents;
using Carter;
using Domain.StronglyTypes;
using Helper.JsuServerResponse;
using Mapster;
using MediatR;

namespace API.Events.EndPoints;

public class EventsCreatedByUser : CarterModule
{
    public EventsCreatedByUser() : base("/Events")
    {
        
    }

    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/Created/{userId:int}", async (int userId, IMediator mediator) =>
        {
            var query = new GetEventsCreatedByUserQuery(UserId.Of(userId));
            var result = await mediator.Send(query);
            return Results.Ok(JsuContractTemplate.GetContractTemplate("Success", result));
        }).DisableAntiforgery();
    }
}
