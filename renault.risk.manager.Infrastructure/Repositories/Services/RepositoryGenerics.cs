using Microsoft.EntityFrameworkCore;
using renault.risk.manager.Application.Interfaces.Repositories;
using renault.risk.manager.Domain.Exceptions;
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
        var response = await _riskManagerContext.Set<T>().ToListAsync();
        if (response.Count == 0)
        {
            throw new NotFoundException($"No records found.");
        }
        return response;
    }
    
    public T? GetById(int id)
    {
        return _riskManagerContext.Set<T>().Find(id);
    }

    public async Task<T> GetByIdAsync(int id)
    {
        var response = await _riskManagerContext.Set<T>().FindAsync(id);
        if (response == null)
        {
            throw new NotFoundException($"No record found with the specified ID.");
        }
        return response;
    }

    public T Update(T entity)
    {
        _riskManagerContext.Set<T>().Update(entity);
        return entity;
    }
    
    public bool Remove(int id)
    {
        var response = GetById(id);
        if (response == null) throw new NotFoundException($"No record found with the specified ID.");
        try
        {
            _riskManagerContext.Set<T>().Remove(response);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public void SaveChange()
    {
        _riskManagerContext.SaveChanges();
    }

    public async Task SaveChangesAsync()
    {
        await _riskManagerContext.SaveChangesAsync();
    }
    
}