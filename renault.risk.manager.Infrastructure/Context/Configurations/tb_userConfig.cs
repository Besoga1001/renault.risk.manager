using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using renault.risk.manager.Domain.Entities;

namespace renault.risk.manager.Infrastructure.Context.Configurations;

public class tb_userConfig : IEntityTypeConfiguration<tb_user>
{
    public void Configure(EntityTypeBuilder<tb_user> builder)
    {
        builder.HasMany(p => p.TbMetiers)
            .WithMany(j => j.TbUsers)
            .UsingEntity(j => j.ToTable("tb_user_metier"));
    }
}