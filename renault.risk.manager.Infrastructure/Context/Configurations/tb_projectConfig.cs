using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using renault.risk.manager.Domain.Entities;

namespace renault.risk.manager.Infrastructure.Context.Configurations;

public class tb_projectConfig : IEntityTypeConfiguration<tb_project>
{
    public void Configure(EntityTypeBuilder<tb_project> builder)
    {
        builder.ToTable(nameof(tb_project))
            .HasKey(nameof(tb_project.pjc_id));
    }
}