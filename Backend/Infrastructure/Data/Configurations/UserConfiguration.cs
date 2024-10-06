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

        builder.Property(p => p.FullName)
            .HasConversion(FullName => FullName.Value, dbFullName => FullName.Of(dbFullName));

        builder.HasData([
            new User() {UserId = UserId.Of("0371098e-898d-45ca-84b2-42790a7ab1c3"), FullName = FullName.Of("Name 1") },
            new User() {UserId = UserId.Of("fb7b0b35-baf2-4718-9bbf-a9ab6206224b"), FullName = FullName.Of("Name 2") },
            new User() {UserId = UserId.Of("243991d2-65dd-4636-868c-1f8f48ab8475"), FullName = FullName.Of("Name 3") },
            new User() {UserId = UserId.Of("4ce8ca07-8f81-4312-93d6-828d336af05b"), FullName = FullName.Of("Name 4") }
            ]);
    }
}
