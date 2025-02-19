using Domain.Models;
using Domain.StronglyTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

public class EventConfiguration : IEntityTypeConfiguration<Event>
{
    public void Configure(EntityTypeBuilder<Event> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(p => p.Id)
            .HasConversion(eventId => eventId.Value, dbEventId => EventId.Of(dbEventId));

        builder.Property(p => p.OwnerId).HasConversion(OwnerId => OwnerId.Value, dbUserId => UserId.Of(dbUserId));

        builder.OwnsOne(p => p.RegistrationInfo);
        builder.OwnsOne(p => p.Targets);

        builder.UseTphMappingStrategy();
    }
}
