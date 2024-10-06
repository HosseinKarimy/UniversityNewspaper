using Application.BazzarHandlers;
using Application.DTO;
using Carter;
using MediatR;

namespace API.Bazaar.EndPoints;


public record GetBannersReques();
public record GetBannerResponse(List<BannerDTO> BannerDTOs);


public class GetBannersEndpoint : CarterModule
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/Banners", async (IMediator mediator) => {

           // var command = request.Adapt<>();
            GetBannerResult result = await mediator.Send(new GetBannersQuery());
            // GetBannerResponse response = result.Adapt<GetBannerResponse>();

            return Results.Ok(result);

        });
    }
}
