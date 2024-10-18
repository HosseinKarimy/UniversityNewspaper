using Domain.Models;

namespace Application.Bazaar.BazzarRepositories;

public interface ICategoryRepository
{
    public Task<List<Category>> GetAllCategoriesAsync(CancellationToken cancellationToken = default);
}
