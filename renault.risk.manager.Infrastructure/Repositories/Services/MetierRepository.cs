using Microsoft.EntityFrameworkCore;
using renault.risk.manager.Application.Interfaces.Repositories;
using renault.risk.manager.Domain.Entities;
using renault.risk.manager.Infrastructure.Context;

namespace renault.risk.manager.Infrastructure.Repositories.Services;

public class MetierRepository : RepositoryGenerics<tb_metier>, IMetierRepository
{
    private readonly RiskManagerContext _riskManagerContext;

    // ReSharper disable once ConvertToPrimaryConstructor
    public MetierRepository(RiskManagerContext context) : base(context)
    {
        _riskManagerContext = context;
    }

    public async Task<List<tb_metier>> GetAllAsync(int? userId, string? metierDescription)
    {
        var query = _riskManagerContext.tb_metiers.AsQueryable();

        if (userId != null)
        {
            query = query.Where(j => j.TbUsers.Any(u => u.usr_id == userId));
        }

        if (!string.IsNullOrWhiteSpace(metierDescription))
        {
            query = query.Where(j => j.met_description.ToUpper().Contains(metierDescription.ToUpper()));
        }

        return await query.ToListAsync();
    }
}