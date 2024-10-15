using Application.Bazaar.BazzarHandlers.AddBanner;
using Application.Bazaar.DTO;
using Carter;
using MediatR;

namespace API.Bazaar.EndPoints
{

    public record UpdateBannerCommand(AddBannerDto BannerDto);
    public record UpdateBannerResponse(bool IsSuccess);

    public class UpdateBannerEndpoint : CarterModule
    {
        public override void AddRoutes(IEndpointRouteBuilder app)
        {
            //create Command
            var command = new UpdateBannerCommand(request.BannerDto);

            //Send Command to Mediator Pipeline
            AddBannerResult result = await mediator.Send(command);

            //Return response to client
            AddBannerResponse response = result.Adapt<AddBannerResponse>();
            return Results.Ok(response.BannerId);
        }
    }
}
