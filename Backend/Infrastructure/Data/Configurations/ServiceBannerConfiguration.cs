using Domain.Models;
using Domain.StronglyTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

public class ServiceBannerConfiguration : IEntityTypeConfiguration<ServiceBanner>
{
    public void Configure(EntityTypeBuilder<ServiceBanner> builder)
    {
        builder.Property(b=>b.ServiceType).IsRequired(false);


        builder.HasData(
            [
            new ServiceBanner(){
                      Id = BannerId.Of(Guid.NewGuid()),
                      CategoryId = CategoryId.Of("af201e39-a2d5-4ccd-9890-fd18ee6490e2"),
                      OwnerId = UserId.Of(8800),
                      CreatedAt = DateTime.Now,
                      Description = "تدریس درس ساختمان داده در دانشگاه",
                      Title = "تدریس ساحتمان",
                      ServiceType = "test"
                }
            ,
            new ServiceBanner(){
                      Id = BannerId.Of(Guid.NewGuid()),
                      CategoryId = CategoryId.Of("af201e39-a2d5-4ccd-9890-fd18ee6490e2"),
                      OwnerId = UserId.Of(8800),
                      CreatedAt = DateTime.Now,
                      Description = "آموزش خطاطی در خوابگاه",
                      Title = "آموزش خطاطی",
                      ServiceType = "گروهی"
                }
            ]);
    }
}
