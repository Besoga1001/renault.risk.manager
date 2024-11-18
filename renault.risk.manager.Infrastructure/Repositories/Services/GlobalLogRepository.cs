using renault.risk.manager.Application.Interfaces.Repositories;
using renault.risk.manager.Domain.Entities;
using renault.risk.manager.Infrastructure.Context;

namespace renault.risk.manager.Infrastructure.Repositories.Services;

public class GlobalLogRepository : RepositoryGenerics<tb_global_log>, IGlobalLogRepository
{
    private readonly RiskManagerContext _riskManagerContext;

    // ReSharper disable once ConvertToPrimaryConstructor
    public GlobalLogRepository(RiskManagerContext context) : base(context)
    {
        _riskManagerContext = context;
    }

}