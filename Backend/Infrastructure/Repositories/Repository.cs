using Application.Bazaar.BazzarRepositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public abstract class Repository<T, Tid>(DbSet<T> dbSet) : IRepository<T, Tid> where T : class
{
    public async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
    {        
        await dbSet.AddAsync(entity, cancellationToken);
        return entity;
    }

    public void Delete(T entity)
    {
        dbSet.Remove(entity);
    }

    public async Task<List<T>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await dbSet.ToListAsync(cancellationToken);
    }

    public async Task<T?> GetByIdAsync(Tid id, CancellationToken cancellationToken = default)
    {
        return await dbSet.FindAsync(id, cancellationToken);
    }

    public void Update(T entity)
    {
        dbSet.Update(entity);
    }
}
