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

        builder.UseTphMappingStrategy()
            .HasDiscriminator(b=>b.Type)
            .HasValue<GoodBanner>(Domain.Enums.BannerType.Goods)
            .HasValue<ServiceBanner>(Domain.Enums.BannerType.Service);

        builder.HasOne<User>(e => e.Owner).WithMany().HasForeignKey(b => b.OwnerId).IsRequired();

        builder.HasOne<Category>(e => e.Category).WithMany().HasForeignKey(b => b.CategoryId).IsRequired();
    }
}
