using Application.Bazaar.BazzarHandlers.GetBanners;
using Application.Bazaar.DTO;
using Carter;
using Mapster;
using MediatR;

namespace API.Bazaar.EndPoints;


public record GetBannersRequest();
public record GetBannerResponse(List<GetBannerDto> BannerDTOs);


public class GetBannersEndpoint : CarterModule
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/Banners", async (IMediator mediator) => {
            
            //create Command
            var query = new GetBannersQuery();

            //Send Query to Mediator Pipeline
            GetBannerResult result = await mediator.Send(query);

            GetBannerResponse response = result.Adapt<GetBannerResponse>();
            return Results.Ok(response);

        });
    }
}
