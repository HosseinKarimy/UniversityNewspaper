using Application.Bazaar.BazzarHandlers.AddBanner;
using Application.Bazaar.DTO;
using Carter;
using Helper.JsuServerResponse;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace API.Bazaar.EndPoints;

public record AddGoodBannerRequest(string Title, string Description, Guid CategoryId, decimal Price)
{
    public IFormFile? Image { get; init; } = null;
}
public record AddServiceBannerRequest(string Title, string Description, Guid CategoryId)
{
    public IFormFile? Image { get; init; } = null;
}

public class AddBannerEndpoint : CarterModule
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {

        var mapGroup = app.MapGroup("/banners");

        MapBannerEndpoint<AddGoodBannerRequest, AddGoodBannerDto, AddGoodBannerCommand>("goods");
        MapBannerEndpoint<AddServiceBannerRequest, AddServiceBannerDto, AddServiceBannerCommand>("services");

        void MapBannerEndpoint<TRequst, TDto, TCommand>(string route) where TDto : AddBannerDto where TCommand : AddBannerCommand
        {
            mapGroup.MapPost($"/{route}", async ([FromForm] TRequst request, IMediator mediator) =>
            {

                var bannerDto = request.Adapt<TDto>();

                //create Command
                var command = Activator.CreateInstance(typeof(TCommand), bannerDto);

                //Send Command to Mediator Pipeline
                AddBannerResult result = (await mediator.Send(command)) as AddBannerResult;

                return Results.Ok(JsuContractTemplate.GetContractTemplate("success", result));
            }).DisableAntiforgery();

        }
    }
}