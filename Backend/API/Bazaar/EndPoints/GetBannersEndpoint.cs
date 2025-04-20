using Application.Bazaar.BazzarHandlers.GetBanners;
using Application.Bazaar.DTO;
using Carter;
using Helper.JsuServerResponse;
using Mapster;
using MediatR;

namespace API.Bazaar.EndPoints;

public record GetBannersResponse(List<BannerDto> Banners);

public class GetBannersEndpoint : CarterModule
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/banners", async (IMediator mediator) =>
           {
               //create Command
               var query = new GetBannersQuery();

               //Send Query to Mediator Pipeline
               GetBannersResult result = await mediator.Send(query);

               GetBannersResponse response = result.Adapt<GetBannersResponse>();               

               return Results.Ok(JsuContractTemplate.GetContractTemplate("Success", response));
           });

    }
}
