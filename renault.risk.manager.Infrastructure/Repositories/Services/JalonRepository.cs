using Microsoft.EntityFrameworkCore;
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

    public async Task<List<tb_jalon>> GetAllAsync(string? jalonDescription)
    {
        var query = _riskManagerContext.tb_jalons.AsQueryable();

        if (!string.IsNullOrWhiteSpace(jalonDescription))
        {
            query = query.Where(j => j.jal_description.ToUpper().Contains(jalonDescription.ToUpper()));
        }

        return await query.ToListAsync();
    }


}