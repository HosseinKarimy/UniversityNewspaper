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
            new User() {Id = UserId.Of(1234) , Role ="teacher" },
            new User() {Id = UserId.Of(1235) , Role ="teacher" },
            new User() {Id = UserId.Of(1236) , Role ="teacher" },
            new User() {Id = UserId.Of(8800) , Role ="student" }
            ]);
    }
}
