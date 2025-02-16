using Domain.Models;
using Domain.StronglyTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

public class AnnouncementConfiguration : IEntityTypeConfiguration<Announcement>
{
    public void Configure(EntityTypeBuilder<Announcement> builder)
    {
        builder.HasKey(a => a.Id);

        builder.Property(p => p.Id)
            .HasConversion(announcementId => announcementId.Value, dbAnnouncementId => AnnouncementId.Of(dbAnnouncementId));

        builder.Property(p => p.OwnerId).HasConversion(OwnerId => OwnerId.Value, dbUserId => UserId.Of(dbUserId));
    }
}
