namespace Application.Bazaar.BazzarRepositories;

public interface IRepository<T,TId> where T : class
{
    public Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);
    public void Update(T entity);
    public void Delete(T entity);
    public Task<T?> GetByIdAsync(TId id, CancellationToken cancellationToken = default);
    public Task<List<T>> GetAllAsync(CancellationToken cancellationToken = default);
}
