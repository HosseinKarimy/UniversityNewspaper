using Domain.Models;
using Domain.StronglyTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

public class BannerConfiguration : IEntityTypeConfiguration<Banner>
{
    public void Configure(EntityTypeBuilder<Banner> builder)
    {
        builder.HasKey(u => u.BannerId);

        builder.Property(p => p.BannerId)
            .HasConversion(bannerId => bannerId.Value, dbBannerId => BannerId.Of(dbBannerId));

        builder.Property(p => p.Title)
            .HasConversion(Title => Title.Value, dbTitle => Title.Of(dbTitle));

        builder.Property(p => p.Description)
            .HasConversion(Description => Description.Value, dbDescription => Description.Of(dbDescription));

        builder.Property(p => p.Description)
            .HasConversion(Description => Description.Value, dbDescription => Description.Of(dbDescription));

        builder.Property(p => p.OwnerId)
            .HasConversion(OwnerId => OwnerId.Value, dbUserId => UserId.Of(dbUserId));

        builder.Property(p => p.CategoryId)
           .HasConversion(CategoryId => CategoryId.Value, dbCategoryId => CategoryId.Of(dbCategoryId));

        builder.Property(p => p.Image)
            .HasConversion(Image => Image.Value, dbImage => ImageURL.Of(dbImage));

        builder.Property(p => p.Price)
            .HasConversion(Price => Price.Value, dbPrice => CurrencyUnit.Of(dbPrice));

        builder.HasOne<User>(e=>e.Owner).WithMany().HasForeignKey(b=>b.OwnerId).IsRequired();

        builder.HasOne<Category>(e=>e.Category).WithMany().HasForeignKey(b => b.CategoryId).IsRequired();
    }
}
