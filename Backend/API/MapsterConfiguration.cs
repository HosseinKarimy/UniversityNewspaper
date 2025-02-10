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
    }
}
