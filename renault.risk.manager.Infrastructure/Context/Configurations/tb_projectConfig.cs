using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using renault.risk.manager.Domain.Entities;

namespace renault.risk.manager.Infrastructure.Context.Configurations;

public class tb_projectConfig : IEntityTypeConfiguration<tb_project>
{
    public void Configure(EntityTypeBuilder<tb_project> builder)
    {
        builder.HasMany(p => p.TbJalons)
            .WithMany(j => j.TbProjects)
            .UsingEntity(j => j.ToTable("tb_project_jalon"));
    }
}