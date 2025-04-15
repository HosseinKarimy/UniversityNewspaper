using Application.Announcements.DTOs;
using Application.Announcements.Handlers.AddAnnouncement;
using Carter;
using Helper.JsuServerResponse;
using MediatR;

namespace API.Announcements.Endpoints;

public class AddAnnouncementEndpoint : CarterModule
{
    public AddAnnouncementEndpoint() : base("/Announcements")
    {
        
    }

    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/", async (AddAnnouncementDto request, IMediator mediator) =>
        {

            var command = new AddAnnouncementCommand(request);

            var result = await mediator.Send(command);

            return Results.Ok(JsuContractTemplate.GetContractTemplate("Success", result));
        }).DisableAntiforgery();
    }
}
