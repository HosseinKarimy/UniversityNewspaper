using Application.Bazaar.BazzarRepositories;
using Domain.Models;
using Infrastructure.Data.ApplicaionDbContetxt;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class CategoryRepository(AppDbContext dbContext) : Repository<Category,Guid>(dbContext.Categories) , ICategoryRepository
{
    public async Task<List<Category>> GetAllCategoriesAsync(CancellationToken cancellationToken = default)
    {
        return await dbContext.Categories.Include(p => p.ChildCategories).ToListAsync(cancellationToken: cancellationToken);
    }
}
