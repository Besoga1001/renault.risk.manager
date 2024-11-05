using renault.risk.manager.Domain.Entities;
using renault.risk.manager.Domain.FiltersDTOs;
using renault.risk.manager.Domain.RequestDTOs;

namespace renault.risk.manager.Application.Interfaces.Repositories;

public interface IRiskRepository : IRepositoryGenerics<tb_risk>
{
    Task AddRangeAsync(List<tb_risk> riskEntities);
    Task<List<tb_risk>> GetAllAsync(RiskFiltersDTO riskFiltersDto);
}