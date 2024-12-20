using renault.risk.manager.Domain.Entities;

namespace renault.risk.manager.Application.Interfaces.Repositories;

public interface IJalonRepository : IRepositoryGenerics<tb_jalon>
{
    Task<List<tb_jalon>> GetAllAsync(string? description);
    List<tb_jalon> GetAll(bool isActive);
}