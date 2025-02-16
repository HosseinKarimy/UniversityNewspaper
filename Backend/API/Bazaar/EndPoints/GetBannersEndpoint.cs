using Application.Bazaar.BazzarHandlers.GetBanners;
using Application.Bazaar.DTO;
using Carter;
using Domain.Enums;
using Helper.JsuServerResponse;
using Mapster;
using MediatR;

namespace API.Bazaar.EndPoints;


//public record GetBannersRequest();
public record GetBannersResponse(List<GoodBannerDto> GoodBanners, List<ServiceBannerDto> ServiceBanners);


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
