using Application.Bazaar.BazzarHandlers.GetBanners;
using Application.Bazaar.BazzarHandlers.GetMyBanners;
using Carter;
using Domain.StronglyTypes;
using Helper.JsuServerResponse;
using Mapster;
using MediatR;

namespace API.Bazaar.EndPoints;

public class GetBannersCreatedByUserEndpoint : CarterModule
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/Banners/Created/{userId:int}", async (int userId,IMediator mediator) => {

            //create Command
            var query = new GetBannersCreatedByUserQuery(UserId.Of(userId));

            //Send Query to Mediator Pipeline
            GetBannersResult result = await mediator.Send(query);

            GetBannersResponse response = result.Adapt<GetBannersResponse>();

            return Results.Ok(JsuContractTemplate.GetContractTemplate(true, response));

        });
    }
}
