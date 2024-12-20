using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using renault.risk.manager.Domain.Entities;

namespace renault.risk.manager.Infrastructure.Context.Configurations;

public class tb_riskConfig  : IEntityTypeConfiguration<tb_risk>
{
    public void Configure(EntityTypeBuilder<tb_risk> builder)
    {
        builder.HasOne(p => p.TbProject)
            .WithMany(r => r.TbRisks)
            .HasForeignKey(p => p.rsk_project_id);

        builder.HasOne(p => p.TbJalon)
            .WithMany(r => r.TbRisks)
            .HasForeignKey(p => p.rsk_jalon_id);

        builder.HasOne(p => p.TbMetier)
            .WithMany(r => r.TbRisks)
            .HasForeignKey(p => p.rsk_metier_id);
    }
}