using API.Bazaar.EndPoints;
using Application.Bazaar.DTO;
using Helper.Helpers;
using Mapster;
namespace API;

public class MapsterConfiguration
{
    public static void MapsterConfigurations()
    {
        TypeAdapterConfig<AddGoodBannerRequest, AddGoodBannerDto>
          .NewConfig()
          .Map(dest => dest.Image, src => FileHelper.SaveFile(src.Image));

        TypeAdapterConfig<BannerDto, BannerDto>
          .NewConfig()
          .Map(dest => dest.Image, src => string.IsNullOrWhiteSpace(src.Image) ? null : "https://10.0.2.2:7159" + src.Image);

        TypeAdapterConfig<GoodBannerDto, GoodBannerDto>
          .NewConfig()
           .Inherits<BannerDto, BannerDto>()
           .Map(dest=> dest.price , src=> src.price);

        TypeAdapterConfig<ServiceBannerDto, ServiceBannerDto>
         .NewConfig()
          .Inherits<BannerDto, BannerDto>();
    }
}
