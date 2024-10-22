using Domain.Enums;

namespace Domain.Models;

public class EventBanner : Banner
{
    public override BannerType BannerType { get; init; } = BannerType.Event;
}
