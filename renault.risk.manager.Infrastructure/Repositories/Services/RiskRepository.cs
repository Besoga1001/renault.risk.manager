using Microsoft.EntityFrameworkCore;
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

    public async Task<List<tb_risk>> GetAllAsync(int? userId)
    {
        var query = _riskManagerContext.tb_risks.AsQueryable();

        if (userId != null)
        {
            query = query.Where(r => r.rsk_usr_id == userId);
        }

        return await query.ToListAsync();
    }
}