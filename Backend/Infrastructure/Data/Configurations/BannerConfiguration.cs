using Domain.Models;
using Domain.StronglyTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

public class BannerConfiguration : IEntityTypeConfiguration<Banner>
{
    public void Configure(EntityTypeBuilder<Banner> builder)
    {
        builder.HasKey(u => u.Id);

        builder.Property(p => p.Id)
            .HasConversion(bannerId => bannerId.Value, dbBannerId => BannerId.Of(dbBannerId));

        builder.Property(p => p.OwnerId)
            .HasConversion(OwnerId => OwnerId.Value, dbUserId => UserId.Of(dbUserId));

        builder.Property(p => p.CategoryId)
           .HasConversion(CategoryId => CategoryId.Value, dbCategoryId => CategoryId.Of(dbCategoryId));

        builder.Property(b => b.Price).HasConversion(Price => Price.Value, dbPrice => CurrencyUnit.Of(dbPrice)).IsRequired(false);

        builder.HasOne<User>(e => e.Owner).WithMany().HasForeignKey(b => b.OwnerId).IsRequired();

        builder.HasOne<Category>(e => e.Category).WithMany().HasForeignKey(b => b.CategoryId).IsRequired();

		builder.HasData(
				[
				new Banner(){
					  Id = BannerId.Of(Guid.NewGuid()),
					  CategoryId = CategoryId.Of("af201e39-a2d5-4ccd-9890-fd18ee6490e2"),
					  OwnerId = UserId.Of(8800),
					  CreatedAt = DateTime.Now,
					  Description = "جزوه دست نویس ساختمان استاد عنایت ترم 403",
					  Title = "جزوه ساحتمان",
					  ImageUrl = "/image 2.png",
					  Price = CurrencyUnit.Of((decimal)1.23)
				} ,

				new Banner(){
					  Id = BannerId.Of(Guid.NewGuid()),
					  CategoryId = CategoryId.Of("af201e39-a2d5-4ccd-9890-fd18ee6490e2"),
					  OwnerId = UserId.Of(8800),
					  CreatedAt = DateTime.Now,
					  Description = "تدریس درس ساختمان داده در دانشگاه",
					  Title = "تدریس ساحتمان"
				}
				,
				new Banner(){
					  Id = BannerId.Of(Guid.NewGuid()),
					  CategoryId = CategoryId.Of("af201e39-a2d5-4ccd-9890-fd18ee6490e2"),
					  OwnerId = UserId.Of(8800),
					  CreatedAt = DateTime.Now,
					  Description = "آموزش خطاطی در خوابگاه",
					  Title = "آموزش خطاطی",
					  Price = CurrencyUnit.Of((decimal)5)
				}
		]);
    }
}
