using Application.Users.DTO;
using Application.Users.Handlers.SetUserAccess;
using Carter;
using Helper.JsuServerResponse;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Users;

public class SetUserAccessEndpoint : CarterModule
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/Users/SetUserAccess", async ([FromBody]UserAccessDto request, IMediator mediator) =>
        {
            var command = new SetUserAccessCommand(request);
            var result = await mediator.Send(command);
            return Results.Ok(JsuContractTemplate.GetContractTemplate("Success"));
        }).DisableAntiforgery();
    }
}
