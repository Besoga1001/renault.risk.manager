using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using renault.risk.manager.Domain.Entities;

namespace renault.risk.manager.Infrastructure.Context.Configurations;

public class tb_userConfig : IEntityTypeConfiguration<tb_user>
{
    public void Configure(EntityTypeBuilder<tb_user> builder)
    {
        builder.ToTable(nameof(tb_user))
            .HasKey(nameof(tb_user.usr_id));
    }
}