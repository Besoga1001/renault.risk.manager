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

        if (riskFiltersDto.ProjectIds != null)
        {
            var projectList = riskFiltersDto.ProjectIds.Split(",").Select(int.Parse).ToList();
            query = query.Where(r => projectList.Contains(r.TbProject.pjc_id));
        }

        if (riskFiltersDto.Description != null)
        {
            query = query.Where(r => r.rsk_description.Contains(riskFiltersDto.Description));
        }

        if (riskFiltersDto.ImpactIds != null)
        {
            var impactList = riskFiltersDto.ImpactIds.Split(",").Select(int.Parse).ToList();
            query = query.Where(r => impactList.Contains((int)r.rsk_impact));
        }

        if (riskFiltersDto.MetierIds != null)
        {
            var metierList = riskFiltersDto.MetierIds.Split(",").Select(int.Parse).ToList();
            query = query.Where(r => metierList.Contains(r.rsk_metier_id));
        }

        if (riskFiltersDto.JalonIds != null)
        {
            var jalonList = riskFiltersDto.JalonIds.Split(",").Select(int.Parse).ToList();
            query = query.Where(r => jalonList.Contains(r.rsk_jalon_id));
        }

        if (riskFiltersDto.StatusIds != null)
        {
            var statusList = riskFiltersDto.StatusIds.Split(",").Select(int.Parse).ToList();
            query = query.Where(r => statusList.Contains((int)r.rsk_status));
        }

        if (riskFiltersDto.IsCaptalization != null)
        {
            query = query.Where(r => r.TbSolution != null
                                     && r.TbSolution.sln_captalization == riskFiltersDto.IsCaptalization);
        }

        return await query.ToListAsync();
    }
}