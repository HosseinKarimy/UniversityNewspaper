using Application.Announcements.Handlers.GetAnnouncements;
using Carter;
using Helper.JsuServerResponse;
using MediatR;

namespace API.Announcements.Endpoints;

public class GetAnnouncementsEndpoint : CarterModule
{
    public GetAnnouncementsEndpoint() : base("/Announcements")
    {
        
    }

    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/", async (IMediator mediator) =>
        {
            var command = new GetAnnouncementsQuery();

            var result = await mediator.Send(command);

            return Results.Ok(JsuContractTemplate.GetContractTemplate("Success", result));
        });
    }
}
