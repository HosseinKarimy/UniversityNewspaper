using Domain.Models;

namespace Application.Bazaar.BazzarRepositories;

public interface ICategoryRepository
{
    public Task<List<Category>> GetCategorieshierarchyAsync(CancellationToken cancellationToken = default);
}
