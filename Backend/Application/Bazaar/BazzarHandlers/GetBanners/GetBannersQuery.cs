using Application.Bazaar.DTO;
using Helper.CQRS;
using Helper.HelperModels;

namespace Application.Bazaar.BazzarHandlers.GetBanners;

public record GetBannersQuery : IQuery<GetBannersResult>
{
    public ImportantHttpContextCarrier ContextCarrier { get; set; } = new();
}

public record GetBannersResult(List<GoodBannerDto> GoodBanners , List<ServiceBannerDto> ServiceBanners);
