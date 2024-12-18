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
                      BannerId = BannerId.Of(Guid.NewGuid()),
                      CategoryId = CategoryId.Of("af201e39-a2d5-4ccd-9890-fd18ee6490e2"),
                      OwnerId = UserId.Of(8800),
                      CreatedAt = DateTime.Now,
                      Description = Description.Of("تدریس درس ساختمان داده در دانشگاه"),
                      Title = Title.Of("تدریس ساحتمان"),
                      Image = ImageURL.Of("image 2"),
                      Price = CurrencyUnit.Of((decimal)1.23)
                }
                ]);
        }

    }
}
