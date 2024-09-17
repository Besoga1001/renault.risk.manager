using Microsoft.EntityFrameworkCore;
using renault.risk.manager.Domain.Entities;

namespace renault.risk.manager.Infrastructure.Context;

public class RiskManagerContext : DbContext
{
    public RiskManagerContext(DbContextOptions<RiskManagerContext> options) : base(options)
    {
        
    }
    
    //DbSets
    public DbSet<tb_project> tb_projects { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    
        // Configurações adicionais de modelagem (opcional)
    }
}