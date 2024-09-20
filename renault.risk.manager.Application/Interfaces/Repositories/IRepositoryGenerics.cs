namespace renault.risk.manager.Infrastructure.Repositories.Interfaces;

public interface IRepositoryGenerics<T>
{
    IEnumerable<T> GetAll();
    Task<IEnumerable<T>> GetAllAsync();
    T? GetById(int id);
    Task<T?> GetByIdAsync(int id);
    bool Remove(int id);
    T Add(in T entity);
    Task<T> AddAsync(T entity);
    T Update(in T entity);
}