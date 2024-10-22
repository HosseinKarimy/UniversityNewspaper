using Domain.Enums;
using Domain.StronglyTypes;

namespace Domain.Models;

public class GoodsBanner : Banner
{
    public override BannerType BannerType { get; init;  } = BannerType.Goods;

    public decimal Price { get; set; }
}
