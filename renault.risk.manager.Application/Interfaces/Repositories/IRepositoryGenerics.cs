namespace renault.risk.manager.Application.Interfaces.Repositories;

public interface IRepositoryGenerics<T>
{
    T? Add(T entity);
    Task<T> AddAsync(T entity);
    List<T> GetAll();
    Task<List<T>> GetAllAsync();
    T? GetById(int id);
    Task<T> GetByIdAsync(int id);
    T Update(T entity);
    bool Remove(int id);
    void SaveChange();
    Task SaveChangesAsync();
}