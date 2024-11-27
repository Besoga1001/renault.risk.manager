using renault.risk.manager.Domain.Entities;

namespace renault.risk.manager.Application.Interfaces.Repositories;

public interface IMetierRepository : IRepositoryGenerics<tb_metier>
{
    Task<List<tb_metier>> GetAllAsync(int? userId, string? description);
    List<tb_metier> GetAll(bool isActive);
}