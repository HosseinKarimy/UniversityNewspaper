using Domain.Models;
using Domain.StronglyTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

public class TagConfiguration : IEntityTypeConfiguration<Tag>
{
    public void Configure(EntityTypeBuilder<Tag> builder)
    {
        builder.HasKey(u => u.TagId);

        builder.Property(p => p.TagId)
            .HasConversion(TagId => TagId.Value, dbTagId => TagId.Of(dbTagId)).IsRequired(true);

        builder.Property(p => p.TagName)
            .HasConversion(TagName => TagName.Value, dbTagName => TagName.Of(dbTagName)).IsRequired(true);

        builder.HasData([
            new Tag() { TagId = TagId.Of("b710d26f-369b-46c3-b133-2e4e522d5530"), TagName = TagName.Of("برچسب 1") },
            new Tag() { TagId = TagId.Of("8c0c0bf0-7dea-4aad-9628-d768a1744355"), TagName = TagName.Of("برچسب 2")},
           ]);
    }
}
