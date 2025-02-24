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

        builder.HasData([
            new User() {Id = UserId.Of(1234) , Role = UserRole.Teacher , Username = "981845112" , Group = TeachingGroup.GermanGroup  },
            new User() {Id = UserId.Of(1235) , Role = UserRole.Teacher , Username = "981845123" , Group = TeachingGroup.ChemistryGroup },
            new User() {Id = UserId.Of(1236) , Role = UserRole.Employee ,Username = "981832131" , Group = TeachingGroup.MathGroup },
            new User() {Id = UserId.Of(8800) , Role = UserRole.Student , Username = "981845138" , Group = TeachingGroup.ComputerGruop }
            ]);
    }
}
