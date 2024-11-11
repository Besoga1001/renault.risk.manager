using Microsoft.EntityFrameworkCore;
using renault.risk.manager.Application.Interfaces.Repositories;
using renault.risk.manager.Domain.Entities;
using renault.risk.manager.Infrastructure.Context;

namespace renault.risk.manager.Infrastructure.Repositories.Services;

public class UserRepository : RepositoryGenerics<tb_user>, IUserRepository
{
    private readonly RiskManagerContext _riskManagerContext;
    
    // ReSharper disable once ConvertToPrimaryConstructor
    public UserRepository(RiskManagerContext context) : base(context)
    {
        _riskManagerContext = context;
    }

    public async Task AddRangeAsync(List<tb_user> userEntities)
    {
        await _riskManagerContext.tb_users.AddRangeAsync(userEntities);
    }

    public async Task<tb_user?> GetByEmailAsync(string email)
    {
        var query = _riskManagerContext.tb_users.AsQueryable();
        
        if (!string.IsNullOrWhiteSpace(email))
        {
            query = query.Where(x => x.usr_email == email);
        }
        
        return await query.FirstOrDefaultAsync();
    }
        
    
}