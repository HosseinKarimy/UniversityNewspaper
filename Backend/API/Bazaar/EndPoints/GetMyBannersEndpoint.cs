using Application.Bazaar.BazzarHandlers.GetMyBanners;
using Application.Bazaar.DTO;
using Carter;
using Helper.JsuServerResponse;
using Mapster;
using MediatR;

namespace API.Bazaar.EndPoints;

public record GetMyBannersRequest();
public record GetMyBannersResponse(IEnumerable<GoodBannerDto> GoodBannersDto, IEnumerable<ServiceBannerDto> ServiceBannersDto);

public class GetMyBannersEndpoint : CarterModule
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/GetMyBanners", async (IMediator mediator) => {

            //create Command
            var query = new GetMyBannersQuery();

            //Send Query to Mediator Pipeline
            GetMyBannersResult result = await mediator.Send(query);

            GetMyBannersResponse response = result.Adapt<GetMyBannersResponse>();

            return Results.Ok(JsuContractTemplate.GetContractTemplate("Success", response));

        });
    }
}
