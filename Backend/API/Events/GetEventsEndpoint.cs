using API.Events.DTO;
using Application.Events.EventsHandlers.GetEvents;
using Carter;
using Domain.Enums;
using Helper.JsuServerResponse;
using Mapster;
using MediatR;

namespace API.Events;

public record EventResponse(List<EventPreviewDto> Events);
public class GetEventsEndpoint : CarterModule
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/Events", async (IMediator mediator) =>
        {
            var query = new GetEventsQuery();
            var result = await mediator.Send(query);
            var response = result.Adapt<EventResponse>();
            return Results.Ok(JsuContractTemplate.GetContractTemplate("Success", response));
        }).DisableAntiforgery();

        app.MapGet("/Events/{id:guid}", async (Guid id ,IMediator mediator) =>
        {
            var query = new GetEventQuery(Domain.StronglyTypes.EventId.Of(id));
            var result = await mediator.Send(query);
            var response = result.Event.Adapt<EventDetailsDto>();
            return Results.Ok(JsuContractTemplate.GetContractTemplate("Success", response));
        }).DisableAntiforgery();
    }
}
