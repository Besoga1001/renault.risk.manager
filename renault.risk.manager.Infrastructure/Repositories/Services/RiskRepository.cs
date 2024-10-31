using renault.risk.manager.Application.Interfaces.Repositories;
using renault.risk.manager.Domain.Entities;
using renault.risk.manager.Domain.RequestDTOs;
using renault.risk.manager.Infrastructure.Context;

namespace renault.risk.manager.Infrastructure.Repositories.Services;

public class RiskRepository : RepositoryGenerics<tb_risk>, IRiskRepository
{
    private readonly RiskManagerContext _riskManagerContext;

    // ReSharper disable once ConvertToPrimaryConstructor
    public RiskRepository(RiskManagerContext context) : base(context)
    {
        _riskManagerContext = context;
    }

    public async Task AddRangeAsync(List<tb_risk> riskEntities)
    {
        await _riskManagerContext.tb_risks.AddRangeAsync(riskEntities);
    }
}