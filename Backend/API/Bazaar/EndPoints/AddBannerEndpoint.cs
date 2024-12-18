using Application.Bazaar.BazzarHandlers.AddBanner;
using Application.Bazaar.DTO;
using Carter;
using Mapster;
using MediatR;

namespace API.Bazaar.EndPoints;

public record AddGoodBannerRequest(AddGoodBannerDto GoodBannerDto);
public record AddServiceBannerRequest(AddServiceBannerDto ServiceBannerDto);
public record AddEventBannerRequest(AddEventBannerDto EventBannerDto);
public record AddBannerResponse(Guid BannerId);

public class AddBannerEndpoint : CarterModule
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/banners/goods", async (AddGoodBannerRequest request, IMediator mediator) =>
        {
            //create Command
            var command = new AddGoodBannerCommand(request.GoodBannerDto);

            //Send Command to Mediator Pipeline
            AddBannerResult result = await mediator.Send(command);

            //Return response to client
            AddBannerResponse response = result.Adapt<AddBannerResponse>();

            return Results.Ok(response.BannerId);
        });



        app.MapPost("/banners/services", async (AddServiceBannerRequest request, IMediator mediator) =>
        {
            //create Command
            var command = new AddServiceBannerCommand(request.ServiceBannerDto);


            //Send Command to Mediator Pipeline
            AddBannerResult result = await mediator.Send(command);


            //Return response to client
            AddBannerResponse response = result.Adapt<AddBannerResponse>();

            return Results.Ok(response.BannerId);
        });



        app.MapPost("/banners/events", async (AddEventBannerRequest request, IMediator mediator) =>
        {
            //create Command
            var command = new AddEventBannerCommand(request.EventBannerDto);


            //Send Command to Mediator Pipeline
            AddBannerResult result = await mediator.Send(command);


            //Return response to client
            AddBannerResponse response = result.Adapt<AddBannerResponse>();

            return Results.Ok(response.BannerId);
        });
    }
}