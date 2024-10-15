using Application.Bazaar.BazzarHandlers;
using Application.Bazaar.DTO;
using Carter;
using Mapster;
using MediatR;

namespace API.Bazaar.EndPoints;

public record AddBannerRequest(AddBannerDto BannerDto);
public record AddBannerResponse(Guid BannerId);

public class AddBannerEndpoint : CarterModule
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/banners", async (AddBannerRequest request, IMediator mediator) =>
        {  
            //create Command
            var command = new AddBannerCommand(request.BannerDto);

            //Send Command to Mediator Pipeline
            AddBannerResult result = await mediator.Send(command);

            //Return response to client
            AddBannerResponse response = result.Adapt<AddBannerResponse>();
            return Results.Ok(response.BannerId);
        });
    }
}
