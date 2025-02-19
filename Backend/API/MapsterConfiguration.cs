using API.Bazaar.EndPoints;
using Application.Bazaar.DTO;
using Application.Events.DTOs;
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

        TypeAdapterConfig<AddServiceBannerRequest, AddServiceBannerDto>
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

        TypeAdapterConfig<AddEventsRequest, AddEventsDto>
          .NewConfig()
          .Map(dest => dest.Targets, src => new TargetUsersDto(src.TargetsRole))
          .Map(dest => dest.RegistrationInfo, src => new RegistrationInfoDto(src.RegisterDeadline , src.RegisterCapacity , src.RegisterFee , src.PaymentType));
    }
}
