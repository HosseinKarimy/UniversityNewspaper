using Application.Bazaar.DTO;
using Domain.Enums;
using Domain.Models;
using Helper.CQRS;
using Helper.HelperModels;

namespace Application.Bazaar.BazzarHandlers.GetBanners;

public record GetBannersQuery(BannerType? RequestedBannerType) : IQuery<GetBannersResult>
{
    public ImportantHttpContextCarrier ContextCarrier { get; set; } = new();
}

public record GetBannersResult(List<GetBannerDto> BannerDTOs);
