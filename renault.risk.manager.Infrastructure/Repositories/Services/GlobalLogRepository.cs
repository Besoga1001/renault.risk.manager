using Microsoft.EntityFrameworkCore;
using renault.risk.manager.Application.Helpers;
using renault.risk.manager.Application.Interfaces.Repositories;
using renault.risk.manager.Domain.Entities;
using renault.risk.manager.Domain.Enums;
using renault.risk.manager.Infrastructure.Context;

namespace renault.risk.manager.Infrastructure.Repositories.Services;

public class GlobalLogRepository : RepositoryGenerics<tb_global_log>, IGlobalLogRepository
{
    private readonly RiskManagerContext riskManagerContext;

    // ReSharper disable once ConvertToPrimaryConstructor
    public GlobalLogRepository(RiskManagerContext context) : base(context)
    {
        riskManagerContext = context;
    }

    public async Task<IEnumerable<tb_global_log>> GetAllAsync(string? logOptionsStringIds)
    {
        var query = riskManagerContext.tb_global_logs.AsQueryable();

        if (logOptionsStringIds == null) return await query.ToListAsync();

        var logOptionsIds = logOptionsStringIds.Split(",").Select(int.Parse).ToList();
        var logOptionDescriptions = new List<string>();
        foreach (var logOptionId in logOptionsIds)
        {
            if (!Enum.IsDefined(typeof(FilterLogOptionsEnum), logOptionId)) continue;

            var logOptionEnumValue = (FilterLogOptionsEnum)logOptionId;
            logOptionDescriptions.Add(logOptionEnumValue.GetDescriptionByDisplay());
        }

        query = query.Where(g => logOptionDescriptions.Contains(g.log_entity_name));

        return await query.ToListAsync();
    }

}