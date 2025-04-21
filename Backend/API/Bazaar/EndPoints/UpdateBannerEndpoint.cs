using Application.Bazaar.BazzarHandlers.UpdateBanner;
using Application.Bazaar.DTO;
using Carter;
using Domain.StronglyTypes;
using Helper.JsuServerResponse;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Bazaar.EndPoints;

public record UpdateBannerRequest(string Title, string Description, Guid CategoryId, decimal Price)
{
    public IFormFile? Image { get; init; } = null;
}
public record UpdateBannerResponse(bool IsSuccess);

public class UpdateBannerEndpoint : CarterModule
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/banners/{id:guid}", async (Guid id,[FromForm] UpdateBannerRequest request, IMediator mediator) =>
        {
            UpdateBannerDto updateBannerDto = request.Adapt<UpdateBannerDto>();

            //create Command
            var command = new UpdateBannerCommand(BannerId.Of(id), updateBannerDto);

            //Send Command to Mediator Pipeline
            UpdateBannerResult result = await mediator.Send(command);

            //Return response to client
            UpdateBannerResponse response = result.Adapt<UpdateBannerResponse>();
            return Results.Ok(JsuContractTemplate.GetContractTemplate(status: response.IsSuccess ? "Success" : "Failed" ));
        }).DisableAntiforgery();
    }
}
