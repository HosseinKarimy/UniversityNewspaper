namespace Application.Bazaar.BazzarRepositories;

public interface IRepository<T,TId> where T : class
{
    public Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);
    public Task<T> UpdateAsync(T entity , CancellationToken cancellationToken = default);
    public Task<T> DeleteAsync(T entity, CancellationToken cancellationToken = default);
    public Task<T> GetByIdAsync(TId id, CancellationToken cancellationToken = default);
    public Task<List<T>> GetAllAsync(CancellationToken cancellationToken = default);
}
