using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using renault.risk.manager.Application.Interfaces.Services;
using renault.risk.manager.Domain.Entities;
using renault.risk.manager.Infrastructure.Context.Configurations;

namespace renault.risk.manager.Infrastructure.Context;

public class RiskManagerContext : DbContext
{
    private readonly IClaimsUserService claimsUserService;

    public RiskManagerContext(
        DbContextOptions<RiskManagerContext> options, IClaimsUserService claimsUserService) : base(options)
    {
        this.claimsUserService = claimsUserService;
    }

    //DbSets
    public DbSet<tb_jalon> tb_jalons { get; set; }
    public DbSet<tb_metier> tb_metiers { get; set; }
    public DbSet<tb_project> tb_projects { get; set; }
    public DbSet<tb_risk> tb_risks { get; set; }
    public DbSet<tb_solution> tb_solutions { get; set; }
    public DbSet<tb_user> tb_users { get; set; }
    public DbSet<tb_global_log> tb_global_logs { get; set; }

    public override int SaveChanges()
    {
        ChangeTracker.DetectChanges();
        TrackInsertsAndChanges();
        return base.SaveChanges();
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        ChangeTracker.DetectChanges();
        TrackInsertsAndChanges();
        return await base.SaveChangesAsync(cancellationToken);
    }

    private void TrackInsertsAndChanges()
    {
        foreach (var entry in ChangeTracker.Entries()
                     .Where(e => e.State is EntityState.Added or EntityState.Modified))
        {
            var entryName = entry.Entity.GetType().Name;
            foreach (var property in entry.Properties)
            {
                UpdateDateTime(property);
                if (entry.State == EntityState.Modified)
                {
                    WriteLog(entryName, property);
                }
            }
        }
    }

    private static void UpdateDateTime(PropertyEntry property)
    {
        if (property.Metadata.ClrType != typeof(DateTime) || property.CurrentValue == null) return;
        var dateTimeValue = (DateTime)property.CurrentValue;
        if (dateTimeValue.Kind == DateTimeKind.Local || dateTimeValue.Kind == DateTimeKind.Unspecified)
        {
            property.CurrentValue = dateTimeValue.ToUniversalTime();
        }
    }

    private void WriteLog(string entityName, PropertyEntry property)
    {
        if (!property.IsModified) return;

        var oldValue = property.OriginalValue?.ToString();
        var newValue = property.CurrentValue?.ToString();
        if (oldValue == newValue) return;

        if (property.Metadata.Name.Contains("updated_at")) return;

        var history = new tb_global_log
        {
            log_entity_name = entityName.Replace("Proxy", ""),
            log_field_name = property.Metadata.Name.Substring(4),
            log_old_value = oldValue ?? "",
            log_new_value = newValue ?? "",
            log_created_at = DateTime.UtcNow,
            log_user_email = claimsUserService.GetCurrentUserEmail()
        };

        tb_global_logs.Add(history);

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