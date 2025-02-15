using Application.Bazaar.BazzarHandlers.GetMyBanners;
using Application.Bazaar.DTO;
using Carter;
using Helper.JsuServerResponse;
using Mapster;
using MediatR;

namespace API.Bazaar.EndPoints;

public record GetMyBannersRequest();
public record GetMyBannersResponse(IEnumerable<GetGoodBannerDto> GoodBannersDto, IEnumerable<GetServiceBannerDto> ServiceBannersDto);

public class GetMyBannersEndpoint : CarterModule
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/GetMyBanners", async (IMediator mediator) => {

            //create Command
            var query = new GetMyBannersQuery();

            //Send Query to Mediator Pipeline
            GetMyBannersResult result = await mediator.Send(query);

            GetMyBannersResponse response = new(result.GoodBannersDto.Select(banner => banner with { Image = "https://10.0.2.2:7159" + banner.Image }), result.ServiceBannersDto.Select(banner => banner with { Image = "https://10.0.2.2:7159" + banner.Image }));

            return Results.Ok(JsuContractTemplate.GetContractTemplate("Success", response));

        });
    }
}
