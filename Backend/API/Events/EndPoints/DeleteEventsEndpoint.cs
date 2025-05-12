using Application.Events.EventsHandlers.DeleteEvent;
using Carter;
using Helper.JsuServerResponse;
using MediatR;

namespace API.Events.EndPoints;

public class DeleteEventsEndpoint : CarterModule
{
    public DeleteEventsEndpoint() : base("/Events")
    {
        
    }
    public override void AddRoutes(IEndpointRouteBuilder app)
    {        
        app.MapDelete("/{id:guid}", async (Guid id, IMediator mediator) =>
        {
            var query = new DeleteEventCommand(Domain.StronglyTypes.EventId.Of(id));
            var result = await mediator.Send(query);
            return Results.Ok(JsuContractTemplate.GetContractTemplate(true));
        }).DisableAntiforgery();

    }
}
