using Microsoft.EntityFrameworkCore;
using renault.risk.manager.Infrastructure.Context;
using renault.risk.manager.Infrastructure.Repositories.Interfaces;

namespace renault.risk.manager.Infrastructure.Repositories.Services;

public class RepositoryGenerics<T> : IRepositoryGenerics<T> where T : class
{
    private readonly RiskManagerContext _context;

    public RepositoryGenerics(RiskManagerContext riskManagerContext)
    {
        _context = riskManagerContext;
    }

    public IEnumerable<T> GetAll()
    {
        return _context.Set<T>().ToList();
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }
    
    public T? GetById(int id)
    {
        return _context.Set<T>().Find(id);
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public bool Remove(int id)
    {
        var entity = GetById(id);
        if (entity == null) return false;
        try
        {
            _context.Set<T>().Remove(entity);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public T Add(in T entity)
    {
        _context.Set<T>().Add(entity);
        _context.SaveChanges();
        return entity;
    }

    public async Task<T> AddAsync(T entity)
    {
        _context.Set<T>().Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public T Update(in T entity)
    {
        _context.Set<T>().Update(entity);
        _context.SaveChanges();
        return entity;
    }
}