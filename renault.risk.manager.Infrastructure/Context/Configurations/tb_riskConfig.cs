using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using renault.risk.manager.Domain.Entities;

namespace renault.risk.manager.Infrastructure.Context.Configurations;

public class tb_riskConfig  : IEntityTypeConfiguration<tb_risk>
{
    public void Configure(EntityTypeBuilder<tb_risk> builder)
    {
        builder.ToTable(nameof(tb_risk))
            .HasKey(nameof(tb_risk.rsk_id));
    }
}