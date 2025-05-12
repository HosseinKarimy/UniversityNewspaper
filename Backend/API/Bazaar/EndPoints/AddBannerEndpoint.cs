using Application.Bazaar.BazzarHandlers.AddBanner;
using Application.Bazaar.DTO;
using Carter;
using Helper.JsuServerResponse;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace API.Bazaar.EndPoints;

public record AddOrUpdateBannerRequest(string Title, string Description, Guid CategoryId)
{
    public IFormFile? Image { get; init; } = null;
    public decimal? Price { get; init; } = null;
}

public class AddBannerEndpoint : CarterModule
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/Banners", async ([FromForm] AddOrUpdateBannerRequest request, IMediator mediator) =>
        {
            var bannerDto = request.Adapt<AddOrUpdateBannerDto>();

            var command = new AddBannerCommand(bannerDto);

            var result = await mediator.Send(command);

            return Results.Ok(JsuContractTemplate.GetContractTemplate(true, result));
        }).DisableAntiforgery();
    }
}