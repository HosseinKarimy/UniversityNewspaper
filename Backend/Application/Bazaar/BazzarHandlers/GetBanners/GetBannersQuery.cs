using Application.Bazaar.DTO;
using Helper.CQRS;
using Helper.HelperModels;

namespace Application.Bazaar.BazzarHandlers.GetBanners;

public record GetBannersQuery() : IQuery<GetBannerResult>
{
    public ImportantHttpContextCarrier ContextCarrier { get; set; } = new();
}

public record GetBannerResult(List<GetBannerDto> BannerDTOs);
