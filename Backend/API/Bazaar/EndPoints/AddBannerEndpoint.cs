using Application.Bazaar.BazzarHandlers.AddBanner;
using Application.Bazaar.DTO;
using Carter;
using Helper.JsuServerResponse;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace API.Bazaar.EndPoints;

public record AddBannerRequest(string Title, string Description, Guid CategoryId, decimal Price)
{
    public IFormFile? Image { get; init; } = null;
}

public class AddBannerEndpoint : CarterModule
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/Banners", async ([FromForm] AddBannerRequest request, IMediator mediator) =>
        {
            var bannerDto = request.Adapt<AddBannerDto>();

            var command = new AddBannerCommand(bannerDto);

            var result = await mediator.Send(command);

            return Results.Ok(JsuContractTemplate.GetContractTemplate("Success", result));
        }).DisableAntiforgery();
    }
}