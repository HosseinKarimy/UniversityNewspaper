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

        builder.HasData([
            new Category() {CategoryId = CategoryId.Of("b710d26f-369b-46c3-b133-2e4e522d5530"), CategoryName = CategoryName.Of("Category 1") },
            new Category() {CategoryId = CategoryId.Of("8c0c0bf0-7dea-4aad-9628-d768a1744355"), CategoryName = CategoryName.Of("Category 2") },
            new Category() {CategoryId = CategoryId.Of("fc2e27bd-5551-4b41-9699-e7a4dc367532"), CategoryName = CategoryName.Of("Category 3") },
            new Category() {CategoryId = CategoryId.Of("3bb92864-b902-4e89-8b97-d049b0b6178a"), CategoryName = CategoryName.Of("Category 4") }
            ]);
    }
}
