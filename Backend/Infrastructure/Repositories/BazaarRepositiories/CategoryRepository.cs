using Application.Bazaar.BazzarRepositories;
using Application.Bazaar.DTO;
using Domain.Models;
using Infrastructure.Data.ApplicaionDbContetxt;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.BazaarRepositiories;

public class CategoryRepository(AppDbContext dbContext) : Repository<Category, Guid>(dbContext.Categories), ICategoryRepository
{
    public async Task<List<Category>> GetCategorieshierarchyAsync(CancellationToken cancellationToken = default)
    {
        // Load all categories into memory
        var categories = await dbContext.Categories.ToListAsync(cancellationToken);

        // Build hierarchy starting from root categories
        var categoryHierarchy = categories
            .Where(c => c.ParentCategoryId == null)
            .Select(c => BuildCategoryHierarchy(c, categories))
            .ToList();

        return categoryHierarchy;
    }

    private static Category BuildCategoryHierarchy(Category category, List<Category> allCategories)
    {
        // Recursively find child categories and attach them
        var children = allCategories
            .Where(c => c.ParentCategoryId == category.CategoryId)
            .Select(c => BuildCategoryHierarchy(c, allCategories))
            .ToList();

        // Set child categories
        category.ChildCategories = children;

        return category;
    }
}
