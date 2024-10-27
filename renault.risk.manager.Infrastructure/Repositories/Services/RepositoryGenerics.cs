using Microsoft.EntityFrameworkCore;
using renault.risk.manager.Application.Interfaces.Repositories;
using renault.risk.manager.Infrastructure.Context;

namespace renault.risk.manager.Infrastructure.Repositories.Services;

public class RepositoryGenerics<T> : IRepositoryGenerics<T> where T : class
{
    private readonly RiskManagerContext _riskManagerContext;

    protected RepositoryGenerics(RiskManagerContext riskManagerContext)
    {
        _riskManagerContext = riskManagerContext;
    }
    
    public T Add(T entity)
    {
        _riskManagerContext.Set<T>().Add(entity);
        return entity;
    }

    public async Task<T> AddAsync(T entity)
    {
        var response = await _riskManagerContext.Set<T>().AddAsync(entity);
        return response.Entity;
    }
    
    public List<T> GetAll()
    {
         return _riskManagerContext.Set<T>().ToList();
    }

    public async Task<List<T>> GetAllAsync()
    {
        return await _riskManagerContext.Set<T>().ToListAsync();
    }
    
    public T? GetById(int id)
    {
        return _riskManagerContext.Set<T>().Find(id);
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        return await _riskManagerContext.Set<T>().FindAsync(id);
    }

    public T Update(T entity)
    {
        _riskManagerContext.Set<T>().Update(entity);
        return entity;
    }
    
    public bool Remove(int id)
    {
        var entity = GetById(id);
        if (entity == null) return false;
        try
        {
            _riskManagerContext.Set<T>().Remove(entity);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool SaveChange()
    {
        try
        {
            _riskManagerContext.SaveChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task<bool> SaveChangesAsync()
    {
        try
        {
            await _riskManagerContext.SaveChangesAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }
    
}