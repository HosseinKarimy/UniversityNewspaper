using Application.Bazaar.BazzarHandlers.DeleteBanner;
using Carter;
using Domain.StronglyTypes;
using Helper.JsuServerResponse;
using MediatR;

namespace API.Bazaar.EndPoints;

public record DeleteBannerRequest();
public record DeleteBannerResponse();

public class DeleteBannerEndpoint : CarterModule
{ 
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/banners/{id:guid}", async (Guid id, IMediator mediator) =>
        {
            //create Command
            var command = new DeleteBannerCommand(BannerId.Of(id));

            //Send Command to Mediator Pipeline
            var result = await mediator.Send(command);

            return Results.Ok(JsuContractTemplate.GetContractTemplate(true));
        });


    }
}


