using Microsoft.EntityFrameworkCore;
using renault.risk.manager.Application.Interfaces.Repositories;
using renault.risk.manager.Domain.Entities;
using renault.risk.manager.Infrastructure.Context;

namespace renault.risk.manager.Infrastructure.Repositories.Services;

public class ProjectRepository : RepositoryGenerics<tb_project>, IProjectRepository
{
    private readonly RiskManagerContext _riskManagerContext;
    
    
    // ReSharper disable once ConvertToPrimaryConstructor
    public ProjectRepository(RiskManagerContext context) : base(context)
    {
        _riskManagerContext = context;
    }

    public async Task<List<tb_project>> GetAllAsyncByName(string name)
    {
        return await _riskManagerContext.tb_projects.Where(r => r.pjc_name == name).ToListAsync();
    }
}