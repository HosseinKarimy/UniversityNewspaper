using API.Bazaar.EndPoints;
using Application.Bazaar.BazzarHandlers.GetBanners;
using Application.Bazaar.BazzarHandlers.GetMyBanners;
using Mapster;
namespace API;

public class MapsterConfiguration
{
    public static void MapsterConfigurations()
    {
        TypeAdapterConfig<GetBannersResult, GetBannersResponse>.NewConfig()
            .Map(dest => dest.BannerDTOs, src => src.BannerDTOs);

        TypeAdapterConfig<GetMyBannersResult, GetMyBannersResponse>.NewConfig()
            .Map(dest => dest.BannerDTOs, src => src.BannerDTOs);
    }
}
