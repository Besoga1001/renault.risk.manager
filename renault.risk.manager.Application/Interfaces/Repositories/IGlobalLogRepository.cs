using renault.risk.manager.Domain.Entities;

namespace renault.risk.manager.Application.Interfaces.Repositories;

public interface IGlobalLogRepository : IRepositoryGenerics<tb_global_log>
{
    Task<IEnumerable<tb_global_log>> GetAllAsync(string? filterLogOptionsEnums);
}