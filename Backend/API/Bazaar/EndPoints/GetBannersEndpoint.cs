using Application.Bazaar.BazzarHandlers.GetBanners;
using Application.Bazaar.DTO;
using Carter;
using Helper.JsuServerResponse;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Bazaar.EndPoints;

public record GetBannersResponse(List<BannerDto> Banners);

public class GetBannersEndpoint : CarterModule
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/GetBanners", async ([FromBody]BannerSearchFilter? Filters ,IMediator mediator) =>
           {
               //create Command
               var query = new GetBannersQuery(Filters ?? new());

               //Send Query to Mediator Pipeline
               var result = await mediator.Send(query);

               //GetBannersResponse response = result.Adapt<GetBannersResponse>();               

               return Results.Ok(JsuContractTemplate.GetContractTemplate("Success", result));
           });

    }
}
