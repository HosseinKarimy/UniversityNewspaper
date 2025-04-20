using Application.Bazaar.BazzarHandlers.GetBanners;
using Domain.StronglyTypes;
using Helper.CQRS;
using Helper.HelperModels;

namespace Application.Bazaar.BazzarHandlers.GetMyBanners;

public record GetBannersCreatedByUserQuery(UserId UserId) : IQuery<GetBannersResult>
{
    public ImportantHttpContextCarrier ContextCarrier { get; set; } = new();
}

