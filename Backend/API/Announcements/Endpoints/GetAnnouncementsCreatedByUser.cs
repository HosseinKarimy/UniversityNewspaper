using Application.Announcements.Handlers.GetAnnouncementsCreatedByUser;
using Carter;
using Domain.StronglyTypes;
using Helper.JsuServerResponse;
using MediatR;

namespace API.Announcements.Endpoints
{
    public class GetAnnouncementsCreatedByUser : CarterModule
    {
        public GetAnnouncementsCreatedByUser() : base("/Announcements")
        {
            
        }

        public override void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/Created/{userId:int}", async (int userId, IMediator mediator) =>
            {
                var command = new GetAnnouncementsCreatedByUserQuery(UserId.Of(userId));

                var result = await mediator.Send(command);

                return Results.Ok(JsuContractTemplate.GetContractTemplate(true, result));
            });
        }
    }
}
