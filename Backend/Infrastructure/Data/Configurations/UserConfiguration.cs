using Domain.Enums;
using Domain.Models;
using Domain.StronglyTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u=>u.Id);

        builder.Property(p => p.Id)
            .HasConversion(UserId => UserId.Value, dbUserId => UserId.Of(dbUserId)).ValueGeneratedNever();

        builder.Property(p => p.CanAddBanner).HasDefaultValue(true);
        builder.Property(p => p.CanAddEvent).HasDefaultValue(false);

        builder.HasData([
            new User() {Id = UserId.Of(1234) , Username = "981845112"  },
            new User() {Id = UserId.Of(1235) , Username = "981845123"  },
            new User() {Id = UserId.Of(1236)  ,Username = "981832131"  },
            new User() {Id = UserId.Of(8800) , Username = "981845138"  }
            ]);
    }
}
