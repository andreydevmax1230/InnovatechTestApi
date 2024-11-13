using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Innovatech.Infraestructure.Configuration;

/// <summary>
/// Generate Configuration name and fields of table Task
/// </summary>
internal class TaskConfiguration : IEntityTypeConfiguration<Domain.Entities.Task>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Task> builder)
    {
        builder.ToTable(string.Format("{0}", nameof(Domain.Entities.Task)));
        builder.Property(c => c.Name).HasMaxLength(128).IsRequired();
        builder.Property(c => c.Description).HasMaxLength(256).IsRequired();
        builder.Property(c => c.DateCompleted).IsRequired();
        builder.Property(c => c.Active).IsRequired();
    }
}