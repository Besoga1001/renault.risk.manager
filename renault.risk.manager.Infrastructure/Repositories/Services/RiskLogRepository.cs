using Microsoft.EntityFrameworkCore;
using renault.risk.manager.Application.Interfaces.Repositories;
using renault.risk.manager.Domain.Entities;
using renault.risk.manager.Domain.FiltersDTOs;
using renault.risk.manager.Infrastructure.Context;

namespace renault.risk.manager.Infrastructure.Repositories.Services;

public class RiskLogRepository : RepositoryGenerics<tb_risk_log>, IRiskLogRepository
{
    private readonly RiskManagerContext _riskManagerContext;

    // ReSharper disable once ConvertToPrimaryConstructor
    public RiskLogRepository(RiskManagerContext context) : base(context)
    {
        _riskManagerContext = context;
    }

}