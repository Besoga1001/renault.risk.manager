using renault.risk.manager.Application.Interfaces.Repositories;
using renault.risk.manager.Infrastructure.Context;

namespace renault.risk.manager.Infrastructure.Repositories.Services;

public class RepositoryGenerics<T>(RiskManagerContext riskManagerContext) : IRepositoryGenerics<T> where T : class
{
    public IEnumerable<T> GetAll()
    {
         return riskManagerContext.Set<T>().AsEnumerable();
    }

    public IAsyncEnumerable<T> GetAllAsync()
    {
        return riskManagerContext.Set<T>().AsAsyncEnumerable();
    }
    
    public T? GetById(int id)
    {
        return riskManagerContext.Set<T>().Find(id);
    }

    public async Task<T?> GetByIdAsync(int id)
    {
         var a = riskManagerContext.Set<T>();
         return null;
    }

    public bool Remove(int id)
    {
        var entity = GetById(id);
        if (entity == null) return false;
        try
        {
            riskManagerContext.Set<T>().Remove(entity);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public T Add(in T entity)
    {
        riskManagerContext.Set<T>().Add(entity);
        riskManagerContext.SaveChanges();
        return entity;
    }

    public async Task<T> AddAsync(T entity)
    {
        riskManagerContext.Set<T>().Add(entity);
        await riskManagerContext.SaveChangesAsync();
        return entity;
    }

    public T Update(in T entity)
    {
        riskManagerContext.Set<T>().Update(entity);
        riskManagerContext.SaveChanges();
        return entity;
    }
}