using Domain.Models;
using Domain.StronglyTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.UserId);

        builder.Property(p => p.UserId)
            .HasConversion(UserId => UserId.Value, dbUserId => UserId.Of(dbUserId));

        builder.HasData([
            new User() {UserId = UserId.Of(1234) },
            new User() {UserId = UserId.Of(1235) },
            new User() {UserId = UserId.Of(1236) },
            new User() {UserId = UserId.Of(8800) }
            ]);
    }
}
