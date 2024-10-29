using renault.risk.manager.Application.Interfaces.Repositories;
using renault.risk.manager.Domain.Entities;
using renault.risk.manager.Infrastructure.Context;

namespace renault.risk.manager.Infrastructure.Repositories.Services;

public class SolutionRepository : RepositoryGenerics<tb_solution>, ISolutionRepository
{
    private readonly RiskManagerContext _riskManagerContext;

    // ReSharper disable once ConvertToPrimaryConstructor
    public SolutionRepository(RiskManagerContext context) : base(context)
    {
        _riskManagerContext = context;
    }
}