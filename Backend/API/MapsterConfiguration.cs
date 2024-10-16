using API.Bazaar.EndPoints;
using Application.Bazaar.BazzarHandlers.GetBanners;
using Mapster;
namespace API;

public class MapsterConfiguration
{
    public static void MapsterConfigurations()
    {
        TypeAdapterConfig<GetBannerResult, GetBannerResponse>.NewConfig()
            .Map(dest => dest.BannerDTOs, src => src.BannerDTOs);    
    }
}
