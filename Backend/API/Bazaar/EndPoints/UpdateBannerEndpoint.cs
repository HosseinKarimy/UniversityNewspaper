using Application.Bazaar.BazzarHandlers.UpdateBanner;
using Application.Bazaar.DTO;
using Carter;
using Helper.JsuServerResponse;
using Mapster;
using MediatR;

namespace API.Bazaar.EndPoints;

public record UpdateGoodBannerRequest(UpdateGoodBannerDto BannerDto);
public record UpdateServiceBannerRequest(UpdateServiceBannerDto BannerDto);
public record UpdateBannerResponse(bool IsSuccess);

public class UpdateBannerEndpoint : CarterModule
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/banners/goods/{id:guid}", async (Guid id, UpdateGoodBannerRequest request, IMediator mediator) =>
        {
            //create Command
            var command = new UpdateGoodBannerCommand(id,request.BannerDto);

            //Send Command to Mediator Pipeline
            UpdateBannerResult result = await mediator.Send(command);

            //Return response to client
            UpdateBannerResponse response = result.Adapt<UpdateBannerResponse>();
            return Results.Ok(JsuContractTemplate.GetContractTemplate(status: response.IsSuccess ? "Success" : "Failed" ));
        });

        app.MapPut("/banners/services/{id:guid}", async (Guid id, UpdateServiceBannerRequest request, IMediator mediator) =>
        {
            //create Command
            var command = new UpdateServiceBannerCommand(id, request.BannerDto);

            //Send Command to Mediator Pipeline
            UpdateBannerResult result = await mediator.Send(command);

            //Return response to client
            UpdateBannerResponse response = result.Adapt<UpdateBannerResponse>();
            return Results.Ok(JsuContractTemplate.GetContractTemplate(status: response.IsSuccess ? "Success" : "Failed"));
        });
    }
}
