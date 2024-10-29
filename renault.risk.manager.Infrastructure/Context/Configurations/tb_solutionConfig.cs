using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using renault.risk.manager.Domain.Entities;

namespace renault.risk.manager.Infrastructure.Context.Configurations;

public class tb_solutionConfig  : IEntityTypeConfiguration<tb_solution>
{
    public void Configure(EntityTypeBuilder<tb_solution> builder)
    {
        builder.ToTable(nameof(tb_solution))
            .HasKey(nameof(tb_solution.sln_id));
    }
}