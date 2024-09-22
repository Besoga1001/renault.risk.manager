namespace renault.risk.manager.Application.Interfaces.Repositories;

public interface IRepositoryGenerics<T>
{
    IEnumerable<T> GetAll();
    IAsyncEnumerable<T> GetAllAsync();
    T? GetById(int id);
    Task<T?> GetByIdAsync(int id);
    bool Remove(int id);
    T Add(in T entity);
    Task<T> AddAsync(T entity);
    T Update(in T entity);
}