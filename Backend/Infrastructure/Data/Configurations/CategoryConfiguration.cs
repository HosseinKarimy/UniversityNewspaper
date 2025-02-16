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

        builder.Property(p => p.ParentCategoryId)
            .HasConversion(ParentCategoryId => ParentCategoryId.Value, dbParentCategoryId => CategoryId.Of(dbParentCategoryId))
            .IsRequired(false);

        builder.HasOne<Category>().WithMany(c => c.ChildCategories).HasForeignKey(p => p.ParentCategoryId).IsRequired(false);

        builder.HasData(seedCategories);
    }

    private readonly List<Category> seedCategories = [

        //level 0
        new Category() { CategoryId = CategoryId.Of("b710d26f-369b-46c3-b133-2e4e522d5530"), CategoryName = "کالا" },
        new Category() { CategoryId = CategoryId.Of("8c0c0bf0-7dea-4aad-9628-d768a1744355"), CategoryName = "خدمات"},
        new Category() { CategoryId = CategoryId.Of("e00948f9-24b8-4e56-939a-ab6b8da2aea4"), CategoryName = "رویداد ها"},

        //level 1: کالا
        new Category() { CategoryId = CategoryId.Of("3bb92864-b902-4e89-8b97-d049b0b6178a"), CategoryName = "کتاب",
            ParentCategoryId = CategoryId.Of("b710d26f-369b-46c3-b133-2e4e522d5530") },
        new Category() { CategoryId = CategoryId.Of("faa97ed3-e098-41a5-84b5-a43f726f2463"), CategoryName = "جزوه",
            ParentCategoryId = CategoryId.Of("b710d26f-369b-46c3-b133-2e4e522d5530") },
        new Category() { CategoryId = CategoryId.Of("37803c15-2f81-4394-8d4a-7b422afc9421"), CategoryName = "لوازم الکترونیکی",
            ParentCategoryId = CategoryId.Of("b710d26f-369b-46c3-b133-2e4e522d5530") },
        new Category() { CategoryId = CategoryId.Of("9a885760-bceb-4c86-bf5c-27f4d296a06d"), CategoryName = "لباس",
            ParentCategoryId = CategoryId.Of("b710d26f-369b-46c3-b133-2e4e522d5530") },
        new Category() { CategoryId = CategoryId.Of("51f54a1e-46ee-4e09-93e1-8498971ef1fc"), CategoryName = "لوازم التحریر",
            ParentCategoryId = CategoryId.Of("b710d26f-369b-46c3-b133-2e4e522d5530") },
        new Category() { CategoryId = CategoryId.Of("0f8d7d43-9d50-4d7a-a15e-6fadfe917d69"), CategoryName = "محصولات بهداشتی",
            ParentCategoryId = CategoryId.Of("b710d26f-369b-46c3-b133-2e4e522d5530") },
        new Category() { CategoryId = CategoryId.Of("9d965187-1b53-482e-aad2-f55193b0d221"), CategoryName = "محصولات هنری",
            ParentCategoryId = CategoryId.Of("b710d26f-369b-46c3-b133-2e4e522d5530") },
        new Category() { CategoryId = CategoryId.Of("cf79f1df-5497-430b-a633-92c7c6fc5af5"), CategoryName = "وسایل تفریح",
            ParentCategoryId = CategoryId.Of("b710d26f-369b-46c3-b133-2e4e522d5530") },

        //level 1: خدمات
        new Category() { CategoryId = CategoryId.Of("ea0516fa-7269-4ee1-b701-6b38048aa5eb"), CategoryName = "آموزشی",
            ParentCategoryId = CategoryId.Of("8c0c0bf0-7dea-4aad-9628-d768a1744355") },
        new Category() { CategoryId = CategoryId.Of("0076fe9e-cd0a-472b-9cfa-7589005c6f9d"), CategoryName = "فنی",
            ParentCategoryId = CategoryId.Of("8c0c0bf0-7dea-4aad-9628-d768a1744355") },
        new Category() { CategoryId = CategoryId.Of("a5167c3c-a786-4052-866b-d863c2d44c63"), CategoryName = "هنری",
            ParentCategoryId = CategoryId.Of("8c0c0bf0-7dea-4aad-9628-d768a1744355") },
        new Category() { CategoryId = CategoryId.Of("a19455b5-f81b-4b93-83e9-330afbde70c8"), CategoryName = "شخصی",
            ParentCategoryId = CategoryId.Of("8c0c0bf0-7dea-4aad-9628-d768a1744355") },

        //level 1: رویداد ها
        new Category() { CategoryId = CategoryId.Of("d3728c0f-f070-477f-a108-ae738d4bf7f6"), CategoryName = "همکاری تیمی",
            ParentCategoryId = CategoryId.Of("e00948f9-24b8-4e56-939a-ab6b8da2aea4") },
        new Category() { CategoryId = CategoryId.Of("53c5608f-73a4-49ff-9d29-cae027c3b7e3"), CategoryName = "کانفرانس و جشنواره",
            ParentCategoryId = CategoryId.Of("e00948f9-24b8-4e56-939a-ab6b8da2aea4") },
        new Category() { CategoryId = CategoryId.Of("9b2fd7d1-62b6-4bc6-a86b-60b9ddaa3eed"), CategoryName = "مسابقات",
            ParentCategoryId = CategoryId.Of("e00948f9-24b8-4e56-939a-ab6b8da2aea4") },
        new Category() { CategoryId = CategoryId.Of("0c92d27d-ef18-4e00-967a-d377c57059b0"), CategoryName = "اردو",
            ParentCategoryId = CategoryId.Of("e00948f9-24b8-4e56-939a-ab6b8da2aea4") },

        //level 2: خدمات - آموزشی
        new Category() { CategoryId = CategoryId.Of("af201e39-a2d5-4ccd-9890-fd18ee6490e2"), CategoryName = "تدریس خصوصی",
            ParentCategoryId = CategoryId.Of("ea0516fa-7269-4ee1-b701-6b38048aa5eb") },
        new Category() { CategoryId = CategoryId.Of("6d5f208d-22f7-4e14-b63e-b1bee8de4fd7"), CategoryName = "تایپ و ترجمه",
            ParentCategoryId = CategoryId.Of("ea0516fa-7269-4ee1-b701-6b38048aa5eb") },
        new Category() { CategoryId = CategoryId.Of("c205a701-8b73-4d37-83b4-ba05140aa16c"), CategoryName = "مشاوره",
            ParentCategoryId = CategoryId.Of("ea0516fa-7269-4ee1-b701-6b38048aa5eb") },

        //level 2: رویداد ها - همکاری تیمی
        new Category() { CategoryId = CategoryId.Of("60b6ac68-2ef5-4443-b7f5-337494c35604"), CategoryName = "درسی و دانشجویی",
            ParentCategoryId = CategoryId.Of("d3728c0f-f070-477f-a108-ae738d4bf7f6") },
        new Category() { CategoryId = CategoryId.Of("a0f45929-9f46-4266-ba60-4e0e1b6ae3c6"), CategoryName = "استارت آپی ، کسب و کار ، بازاریابی",
            ParentCategoryId = CategoryId.Of("d3728c0f-f070-477f-a108-ae738d4bf7f6") },
        new Category() { CategoryId = CategoryId.Of("b3240648-e8ab-45b9-86c1-efe9cdfcc607"), CategoryName = "تیم های هنری، تئاتر ، برگزاری نمیشگاه و",
            ParentCategoryId = CategoryId.Of("d3728c0f-f070-477f-a108-ae738d4bf7f6") },
        ];
}
