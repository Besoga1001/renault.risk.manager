using Microsoft.EntityFrameworkCore;
using renault.risk.manager.Domain.Entities;
using renault.risk.manager.Infrastructure.Context.Configurations;

namespace renault.risk.manager.Infrastructure.Context;

public class RiskManagerContext : DbContext
{
    public RiskManagerContext(DbContextOptions<RiskManagerContext> options) : base(options)
    {
        
    }
    
    //DbSets
    public DbSet<tb_project> tb_projects { get; set; }
    public DbSet<tb_user> tb_users { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new tb_projectConfig());
        modelBuilder.ApplyConfiguration(new tb_userConfig());
    }
}