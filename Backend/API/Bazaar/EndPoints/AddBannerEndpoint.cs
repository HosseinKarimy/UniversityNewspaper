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
        app.MapPost("/banners", async (AddBannerRequest request, IMediator mediator) =>
        {
            AddBannerCommand command = request.Adapt<AddBannerCommand>();
            AddBannerResult result = await mediator.Send(command);
            AddBannerResponse response = result.Adapt<AddBannerResponse>();

            return Results.Ok(response);
        });
    }
}
