using Application.Bazaar.BazzarHandlers.GetBanners;
using Application.Bazaar.DTO;
using Carter;
using Domain.Enums;
using Helper.JsuServerResponse;
using MediatR;

namespace API.Bazaar.EndPoints;


//public record GetBannersRequest();
public record GetBannersResponse(List<GetBannerDto> BannerDTOs);


public class GetBannersEndpoint : CarterModule
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        var mapGroup = app.MapGroup("/banners");
        MapGoodBanners<GetGoodBannerDto>(BannerType.Goods, "goods");
        MapGoodBanners<GetServiceBannerDto>(BannerType.Service, "services");

        void MapGoodBanners<TResult>(BannerType type , string route) where TResult : GetBannerDto
        {
            mapGroup.MapGet($"/{route}", async (IMediator mediator) =>
            {

                //create Command
                var query = new GetBannersQuery(type);

                //Send Query to Mediator Pipeline
                GetBannersResult result = await mediator.Send(query);

                //GetBannersResponse response = result.Adapt<GetBannersResponse>();
                var data = result.BannerDTOs.Cast<TResult>()
                .Select(banner => banner with { Image = "https://10.0.2.2:7159" + banner.Image }); ;
                return Results.Ok(JsuContractTemplate.GetContractTemplate("Success", data));
            });
        }

    }
}
