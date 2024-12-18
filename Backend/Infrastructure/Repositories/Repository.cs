using Application.Bazaar.BazzarRepositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Infrastructure.Repositories;

public class Repository<T, Tid> : IRepository<T, Tid> where T : class
{
    private readonly DbSet<T> dbSet;

    public Repository(DbSet<T> dbSet)
    {
        this.dbSet = dbSet;
    }

    public async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
    {        
        await dbSet.AddAsync(entity, cancellationToken);
        return entity;
    }

    public Task<T> DeleteAsync(T entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<List<T>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<T> GetByIdAsync(Tid id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<T> UpdateAsync(T entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
