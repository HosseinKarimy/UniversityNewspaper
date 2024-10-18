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
            .HasConversion(CategoryId => CategoryId.Value, dbCategoryId => CategoryId.Of(dbCategoryId)!);

        builder.Property(p => p.CategoryName)
            .HasConversion(CategoryName => CategoryName.Value, dbCategoryName => CategoryName.Of(dbCategoryName));

        builder.Property(p => p.ParentCategoryId)
            .HasConversion(ParentCategoryId => ParentCategoryId.Value, dbParentCategoryId => CategoryId.Of(dbParentCategoryId))
            .IsRequired(false);

        builder.HasOne<Category>().WithMany(c => c.ChildCategories).HasForeignKey(p=>p.ParentCategoryId).IsRequired(false);

        builder.HasData([
            new Category() {CategoryId = CategoryId.Of("b710d26f-369b-46c3-b133-2e4e522d5530"), CategoryName = CategoryName.Of("Cat1") },
            new Category() {CategoryId = CategoryId.Of("8c0c0bf0-7dea-4aad-9628-d768a1744355"), CategoryName = CategoryName.Of("Cat1-1") , ParentCategoryId = CategoryId.Of("b710d26f-369b-46c3-b133-2e4e522d5530") },

            new Category() {CategoryId = CategoryId.Of("fc2e27bd-5551-4b41-9699-e7a4dc367532"), CategoryName = CategoryName.Of("Cat2") },
            new Category() {CategoryId = CategoryId.Of("3bb92864-b902-4e89-8b97-d049b0b6178a"), CategoryName = CategoryName.Of("Cat2-1") ,  ParentCategoryId = CategoryId.Of("fc2e27bd-5551-4b41-9699-e7a4dc367532") },
            new Category() {CategoryId = CategoryId.Of("faa97ed3-e098-41a5-84b5-a43f726f2463"), CategoryName = CategoryName.Of("Cat2-2") ,  ParentCategoryId = CategoryId.Of("fc2e27bd-5551-4b41-9699-e7a4dc367532") },
             new Category() {CategoryId = CategoryId.Of("37803c15-2f81-4394-8d4a-7b422afc9421"), CategoryName = CategoryName.Of("Cat2-3") ,  ParentCategoryId = CategoryId.Of("fc2e27bd-5551-4b41-9699-e7a4dc367532") },
             new Category() {CategoryId = CategoryId.Of("30131921-1d66-49a7-9fd1-a74b1a6e57a8"), CategoryName = CategoryName.Of("Cat2-3-1") ,  ParentCategoryId = CategoryId.Of("37803c15-2f81-4394-8d4a-7b422afc9421") },
            ]);
    }
}
