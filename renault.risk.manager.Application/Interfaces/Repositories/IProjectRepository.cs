using renault.risk.manager.Domain.Entities;

namespace renault.risk.manager.Application.Interfaces.Repositories;

public interface IProjectRepository : IRepositoryGenerics<tb_project>
{ 
    Task<List<tb_project>> GetAllAsync(string? name);
}