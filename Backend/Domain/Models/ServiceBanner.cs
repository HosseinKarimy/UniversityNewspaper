using Domain.Enums;

namespace Domain.Models;

public class ServiceBanner : Banner
{
    public override BannerType BannerType { get; init; } = BannerType.Service;

    public string ServiceType { get; set; }
}
