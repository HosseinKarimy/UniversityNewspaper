using Application.Events.DTOs;
using Application.Events.EventsHandlers.UpdateEvent;
using Carter;
using Helper.JsuServerResponse;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Events.EndPoints
{
    public class UpdateEventEndpoint : CarterModule
    {
        public override void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/Events/{eventId:guid}", async (Guid eventId,[FromForm] AddOrUpdateEventRequest request, IMediator mediator) =>
            {
                var addEventDto = request.Adapt<AddOrUpdateEventDto>();

                var command = new UpdateEventCommand(Domain.StronglyTypes.EventId.Of(eventId),addEventDto);

                var result = await mediator.Send(command);

                return Results.Ok(JsuContractTemplate.GetContractTemplate(true, result));
            }).DisableAntiforgery();
        }
    }
}
