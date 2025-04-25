using API.Bazaar.EndPoints;
using API.Events.EndPoints;
using Application.Bazaar.DTO;
using Application.Events.DTOs;
using Domain.Enums;
using Helper.Helpers;
using Mapster;
namespace API;

public class MapsterConfiguration
{
    public static void MapsterConfigurations()
    {
        TypeAdapterConfig<AddBannerRequest, AddBannerDto>
          .NewConfig()
          .Map(dest => dest.Image, src => FileHelper.SaveFile(src.Image));

        TypeAdapterConfig<BannerDto, BannerDto>
          .NewConfig()
          .Map(dest => dest.Image, src => string.IsNullOrWhiteSpace(src.Image) ? null : "https://10.0.2.2:7159" + src.Image);

        TypeAdapterConfig<AddEventsRequest, AddEventsDto>
          .NewConfig()
          .Map(dest => dest.Organizers, src => ParsingToEnum<Department>(src.Organizers))
          .Map(dest => dest.RegistrationInfo, src => new RegistrationInfoDto(src.RegisterDeadline , src.RegisterCapacity , src.RegisterFee))
          .Map(dest => dest.ImageURl, src => FileHelper.SaveFile(src.Image));

        //TypeAdapterConfig<EventDto, Event>
        //  .NewConfig()
        //  .Map(dest => dest.ImageUrl, src => string.IsNullOrWhiteSpace(src.ImageUrl) ? null : "https://10.0.2.2:7159" + src.ImageUrl);

    }

    private static List<TEnum>? ParsingToEnum<TEnum>(string? data) where TEnum : struct, Enum
    {
        var array = data?.Split(',');
        return array?.SelectMany(str =>
            {
                return Enum.TryParse<TEnum>(str, true, out var parsedEnum)
                    ? [parsedEnum]
                    : new List<TEnum>();
            })
            .ToList();
    }

}
