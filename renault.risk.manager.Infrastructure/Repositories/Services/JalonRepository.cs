using renault.risk.manager.Application.Interfaces.Repositories;
using renault.risk.manager.Domain.Entities;
using renault.risk.manager.Infrastructure.Context;

namespace renault.risk.manager.Infrastructure.Repositories.Services;

public class JalonRepository : RepositoryGenerics<tb_jalon>, IJalonRepository
{
    private readonly RiskManagerContext _riskManagerContext;

    // ReSharper disable once ConvertToPrimaryConstructor
    public JalonRepository(RiskManagerContext context) : base(context)
    {
        _riskManagerContext = context;
    }

}