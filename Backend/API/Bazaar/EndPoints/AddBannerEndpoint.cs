using Application.BazaarHandlers;
using Application.DTO;
using Carter;
using Domain.Models;
using Mapster;
using MediatR;

namespace API.Bazaar.EndPoints;

public record AddBannerRequest(BannerDTO BannerDto);
public record AddBannerResponse(Banner Banner);

public class AddBannerEndpoint : CarterModule
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/banner", (AddBannerRequest request, IMediator mediator) =>
        {

            var command = request.Adapt<AddBannerCommand>();
            var result = mediator.Send(command);
            var response = result.Adapt<AddBannerResponse>();

            return Results.Ok(response);
        });
    }
}
