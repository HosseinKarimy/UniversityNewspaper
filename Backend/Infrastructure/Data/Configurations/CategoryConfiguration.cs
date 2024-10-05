using Domain.Models;
using Domain.StronglyTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(u => u.CategoryId);

        builder.Property(p => p.CategoryId)
            .HasConversion(CategoryId => CategoryId.Value, dbCategoryId => CategoryId.Of(dbCategoryId));

        builder.Property(p => p.CategoryName)
            .HasConversion(CategoryName => CategoryName.Value, dbCategoryName => CategoryName.Of(dbCategoryName));
    }
}
