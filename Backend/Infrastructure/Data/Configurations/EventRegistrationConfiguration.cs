using Domain.Models;
using Domain.StronglyTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

public class EventRegistrationConfiguration : IEntityTypeConfiguration<EventRegistration>
{
    public void Configure(EntityTypeBuilder<EventRegistration> builder)
    {
        builder.HasKey(p => new { p.EventId , p.UserId});

        builder.Property(p => p.EventId)
            .HasConversion(eventId => eventId.Value, dbEventId => EventId.Of(dbEventId));
        builder.Property(p => p.UserId)
            .HasConversion(UserId => UserId.Value, dbUserId => UserId.Of(dbUserId));

        builder.HasOne(er => er.User).WithMany().HasForeignKey(er => er.UserId);
        builder.HasOne(er => er.Event).WithMany(e=>e.Registrations).HasForeignKey(er => er.EventId);

    }
}
