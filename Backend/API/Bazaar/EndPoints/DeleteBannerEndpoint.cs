using Application.Bazaar.BazzarHandlers.DeleteBanner;
using Carter;
using Helper.JsuServerResponse;
using MediatR;

namespace API.Bazaar.EndPoints;

public record DeleteBannerRequest();
public record DeleteBannerResponse();

public class DeleteBannerEndpoint : CarterModule
{ 
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/banners/goods/{id:guid}", async (Guid id, IMediator mediator) =>
        {
            //create Command
            var command = new DeleteBannerCommand(id,Domain.Enums.BannerType.Goods);

            //Send Command to Mediator Pipeline
            DeleteBannerResult result = await mediator.Send<DeleteBannerResult>(command);

            return Results.Ok(JsuContractTemplate.GetContractTemplate("Success"));
        });

        app.MapDelete("/banners/services/{id:guid}", async (Guid id, IMediator mediator) =>
        {
            //create Command
            var command = new DeleteBannerCommand(id, Domain.Enums.BannerType.Service);

            //Send Command to Mediator Pipeline
            DeleteBannerResult result = await mediator.Send<DeleteBannerResult>(command);

            return Results.Ok(JsuContractTemplate.GetContractTemplate("Success"));
        });

    }
}


