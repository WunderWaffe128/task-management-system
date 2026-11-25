using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManager.Core.Entities;

namespace TaskManager.Infrastructure.Data.Configurations
{
    public class SubTaskConfiguration : IEntityTypeConfiguration<SubTask>
    {
        public void Configure(EntityTypeBuilder<SubTask> builder)
        {
            builder.ToTable("SubTasks");
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Title)
                   .IsRequired()
                   .HasMaxLength(255);
            builder.Property(s => s.IsCompleted)
                   .IsRequired()
                   .HasDefaultValue(false);
        }
    }
}
