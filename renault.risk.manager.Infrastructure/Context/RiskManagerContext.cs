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
    public DbSet<tb_risk> tb_risks { get; set; }
    public DbSet<tb_solution> tb_solutions { get; set; }
    public DbSet<tb_user> tb_users { get; set; }

    public override int SaveChanges()
    {
        // Detecta alterações nas entidades para capturar suas propriedades
        ChangeTracker.DetectChanges();

        foreach (var entry in ChangeTracker.Entries()
                     .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified))
        {
            foreach (var property in entry.Properties)
            {
                // Verifica se a propriedade é do tipo DateTime
                if (property.Metadata.ClrType == typeof(DateTime) && property.CurrentValue != null)
                {
                    // Converte para UTC caso não esteja definido como UTC
                    var dateTimeValue = (DateTime)property.CurrentValue;
                    if (dateTimeValue.Kind == DateTimeKind.Local || dateTimeValue.Kind == DateTimeKind.Unspecified)
                    {
                        property.CurrentValue = dateTimeValue.ToUniversalTime();
                    }
                }
            }
        }

        return base.SaveChanges();
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        ChangeTracker.DetectChanges();

        foreach (var entry in ChangeTracker.Entries()
                     .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified))
        {
            foreach (var property in entry.Properties)
            {
                if (property.Metadata.ClrType == typeof(DateTime) && property.CurrentValue != null)
                {
                    var dateTimeValue = (DateTime)property.CurrentValue;
                    if (dateTimeValue.Kind == DateTimeKind.Local || dateTimeValue.Kind == DateTimeKind.Unspecified)
                    {
                        property.CurrentValue = dateTimeValue.ToUniversalTime();
                    }
                }
            }
        }

        return await base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // modelBuilder.ApplyConfiguration(new tb_projectConfig());
        modelBuilder.ApplyConfiguration(new tb_riskConfig());
        // modelBuilder.ApplyConfiguration(new tb_userConfig());
        // modelBuilder.ApplyConfiguration(new tb_solutionConfig());
    }
}