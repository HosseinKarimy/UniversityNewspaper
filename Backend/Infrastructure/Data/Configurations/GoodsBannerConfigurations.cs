using Domain.Models;
using Domain.StronglyTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class GoodsBannerConfigurations : IEntityTypeConfiguration<GoodBanner>
    {
        public void Configure(EntityTypeBuilder<GoodBanner> builder)
        {
            builder.Property(b => b.Price).HasConversion(Price => Price.Value, dbPrice => CurrencyUnit.Of(dbPrice)).IsRequired(true);

            builder.HasData(
                [
                new GoodBanner(){
                      Id = BannerId.Of(Guid.NewGuid()),
                      CategoryId = CategoryId.Of("af201e39-a2d5-4ccd-9890-fd18ee6490e2"),
                      OwnerId = UserId.Of(8800),
                      CreatedAt = DateTime.Now,
                      Description = "جزوه دست نویس ساختمان استاد عنایت ترم 403",
                      Title = "جزوه ساحتمان",
                      ImageUrl = "/image 2.png",
                      Price = CurrencyUnit.Of((decimal)1.23)
                }
                ]);
        }

    }
}
