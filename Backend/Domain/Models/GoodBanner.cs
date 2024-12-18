using Domain.Enums;
using Domain.StronglyTypes;

namespace Domain.Models;

public class GoodBanner : Banner
{
    public CurrencyUnit Price { get; set; }
}
