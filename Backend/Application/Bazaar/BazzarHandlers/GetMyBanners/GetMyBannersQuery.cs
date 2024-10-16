using Application.Bazaar.DTO;
using Helper.CQRS;
using Helper.HelperModels;

namespace Application.Bazaar.BazzarHandlers.GetMyBanners;

public class GetMyBannersQuery : IQuery<GetMyBannersResult>
{
    public ImportantHttpContextCarrier ContextCarrier { get; set; } = new();
}

public record GetMyBannersResult(List<GetBannerDto> BannerDTOs);
