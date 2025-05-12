using Application.Users.Handlers.GetUserStatus;
using Carter;
using Domain.StronglyTypes;
using Helper.JsuServerResponse;
using Mapster;
using MediatR;

namespace API.Users;

public record UserStatusResponseDto(int UserId , int BannerCount , int EventCount , bool CanAddBanner , bool CanAddEvent);

public class GetUserStatusEndpoint : CarterModule
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/Users/Status/{userId:int}", async (int userId , IMediator mediator) =>
        {
            var query = new GetUserStatusQuery(UserId.Of(userId));
            var result = await mediator.Send(query);
            var response = result.Adapt<UserStatusResponseDto>();
            return Results.Ok(JsuContractTemplate.GetContractTemplate(true, response));
        }).DisableAntiforgery();
    }
}
