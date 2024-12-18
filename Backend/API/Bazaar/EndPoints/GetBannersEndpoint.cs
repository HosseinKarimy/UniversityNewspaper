using Application.Bazaar.BazzarHandlers.GetBanners;
using Application.Bazaar.DTO;
using Carter;
using Mapster;
using MediatR;

namespace API.Bazaar.EndPoints;


//public record GetBannersRequest();
public record GetBannersResponse(List<GetBannerDto> BannerDTOs);


public class GetBannersEndpoint : CarterModule
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/Banners/goods", async (IMediator mediator) => {

            //create Command
            var query = new GetBannersQuery(Domain.Enums.BannerType.Goods);

            //Send Query to Mediator Pipeline
            GetBannersResult result = await mediator.Send(query);

            GetBannersResponse response = result.Adapt<GetBannersResponse>();
            return Results.Ok(response);

        });

        app.MapGet("/Banners/services", async (IMediator mediator) => {

        });

        app.MapGet("/Banners/events", async (IMediator mediator) => {


        });

    }
}
