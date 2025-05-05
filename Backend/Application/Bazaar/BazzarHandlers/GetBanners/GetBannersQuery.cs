using Application.Bazaar.DTO;
using Helper.CQRS;
using Helper.HelperModels;

namespace Application.Bazaar.BazzarHandlers.GetBanners;

public record GetBannersQuery(BannerSearchFilter Filters) : IQuery<PaginatedResult<BannerDto>>
{
    public ImportantHttpContextCarrier ContextCarrier { get; set; } = new();
}

public record GetBannersResult(List<BannerDto> Banners);
