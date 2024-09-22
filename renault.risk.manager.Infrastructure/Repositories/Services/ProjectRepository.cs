using renault.risk.manager.Application.Interfaces.Repositories;
using renault.risk.manager.Domain.Entities;
using renault.risk.manager.Infrastructure.Context;

namespace renault.risk.manager.Infrastructure.Repositories.Services;

public class ProjectRepository : RepositoryGenerics<tb_project>, IProjectRepository
{
    public ProjectRepository(RiskManagerContext context) : base(context)
    {
        
    }
}