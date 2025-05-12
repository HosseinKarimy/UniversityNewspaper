using Application.Bazaar.BazzarHandlers.GetCategories;
using Carter;
using Helper.JsuServerResponse;
using MediatR;

namespace API.Bazaar.EndPoints;

public record GetCategoriesRequest();
//public record GetCategoriesResponse(List<CategoryDto> CategiriesDto);

public class GetCategoriesEndpoint : CarterModule
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/GetCategories", async (IMediator mediator) => {

            //create Command
            var query = new GetCategoriesQuery();

            //Send Query to Mediator Pipeline
            GetCategoriesResult result = await mediator.Send(query);

            //GetMyBannersResponse response = result.Adapt<GetMyBannersResponse>();

            return Results.Ok(JsuContractTemplate.GetContractTemplate(true, result.CategoriesDto));

        });
    }
}
