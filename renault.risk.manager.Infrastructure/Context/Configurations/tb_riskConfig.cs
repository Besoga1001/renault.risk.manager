using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using renault.risk.manager.Domain.Entities;

namespace renault.risk.manager.Infrastructure.Context.Configurations;

public class tb_riskConfig  : IEntityTypeConfiguration<tb_risk>
{
    public void Configure(EntityTypeBuilder<tb_risk> builder)
    {
        // builder.ToTable(nameof(tb_risk))
        //     .HasKey(e => e.rsk_id);
        //
        // builder.Property(e => e.rsk_id)
        //     .ValueGeneratedOnAdd();

        // builder.HasOne(y => y.TbSolution)
        //     .WithOne(x => x.TbRisk)
        //     .HasForeignKey<tb_solution>(x => x.sln_risk_id);
    }
}