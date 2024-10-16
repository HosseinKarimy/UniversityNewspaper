using Application.Bazaar.BazzarHandlers.UpdateBanner;
using Application.Bazaar.DTO;
using Carter;
using Mapster;
using MediatR;

namespace API.Bazaar.EndPoints
{

    public record UpdateBannerRequest(UpdateBannerDto BannerDto);
    public record UpdateBannerResponse(bool IsSuccess);

    public class UpdateBannerEndpoint : CarterModule
    {
        public override void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPut("/banners", async (UpdateBannerRequest request, IMediator mediator) =>
            {
                //create Command
                var command = new UpdateBannerCommand(request.BannerDto);

                //Send Command to Mediator Pipeline
                UpdateBannerResult result = await mediator.Send(command);

                //Return response to client
                UpdateBannerResponse response = result.Adapt<UpdateBannerResponse>();
                return Results.Ok(response.IsSuccess);
            });
        }
    }
}
