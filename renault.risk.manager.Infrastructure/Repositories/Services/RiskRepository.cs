using Microsoft.EntityFrameworkCore;
using renault.risk.manager.Application.Interfaces.Repositories;
using renault.risk.manager.Domain.Entities;
using renault.risk.manager.Domain.FiltersDTOs;
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

    public async Task<List<tb_risk>> GetAllAsync(RiskFiltersDTO riskFiltersDto)
    {
        var query = _riskManagerContext.tb_risks.AsQueryable();

        if (riskFiltersDto.ProjectId != null)
        {
            query = query.Where(r => r.TbProject.pjc_id == riskFiltersDto.ProjectId);
        }

        if (riskFiltersDto.Description != null)
        {
            query = query.Where(r => r.rsk_description.Contains(riskFiltersDto.Description));
        }

        if (riskFiltersDto.ImpactId != null)
        {
            query = query.Where(r => r.rsk_impact == riskFiltersDto.ImpactId);
        }

        if (riskFiltersDto.MetierId != null)
        {
            query = query.Where(r => r.rsk_metier == riskFiltersDto.MetierId);
        }

        if (riskFiltersDto.JalonId != null)
        {
            query = query.Where(r => r.rsk_jalon == riskFiltersDto.JalonId);
        }

        if (riskFiltersDto.StatusId != null)
        {
            query = query.Where(r => r.rsk_status == riskFiltersDto.StatusId);
        }

        if (riskFiltersDto.IsCaptalization != null)
        {
            query = query.Where(r => r.TbSolution != null
                                     && r.TbSolution.sln_captalization == riskFiltersDto.IsCaptalization);
        }

        return await query.ToListAsync();
    }
}