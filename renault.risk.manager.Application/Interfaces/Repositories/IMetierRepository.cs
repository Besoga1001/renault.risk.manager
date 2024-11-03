using renault.risk.manager.Domain.Entities;

namespace renault.risk.manager.Application.Interfaces.Repositories;

public interface IMetierRepository : IRepositoryGenerics<tb_metier>
{
    Task<List<tb_metier>> GetAllAsync(string? description);
}