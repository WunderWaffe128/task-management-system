using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManager.Core.Entities;

namespace TaskManager.Infrastructure.Data.Configurations
{
    public class TaskItemConfiguration : IEntityTypeConfiguration<TaskItem>
    {
        public void Configure(EntityTypeBuilder<TaskItem> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Title)
                   .IsRequired()
                   .HasMaxLength(150);
            builder.Property(t => t.Description)
                   .IsRequired();
            builder.Property(t => t.Status)
                   .IsRequired()
                   .HasMaxLength(50)
                   .HasDefaultValue("To Do");
            builder.Property(t => t.Priority)
                   .IsRequired()
                   .HasMaxLength(50)
                   .HasDefaultValue("Medium");
            builder.Property(t => t.Deadline)
                .IsRequired()
                .HasColumnType("datetime");
            builder.HasMany(t => t.SubTasks)
                   .WithOne(s => s.Task)
                   .HasForeignKey(t => t.TaskId)
                   .OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(t => t.Comments)
                   .WithOne(c => c.Task)
                   .HasForeignKey(t => t.TaskId)
                   .OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(t => t.TaskHistories)
                   .WithOne(th => th.Task)
                   .HasForeignKey(t => t.TaskId)
                   .OnDelete(DeleteBehavior.Cascade);
            builder.ToTable("Tasks", table =>
            {
                table.HasCheckConstraint(
                "CK_Task_Status",
                   "[Status] IN ('To Do','In Progress','Done')");
                table.HasCheckConstraint(
                    "CK_TASK_PRIORITY",
                    "[Priority] IN ('Low','Medium','High','Critical')");
            });
        }
    }
}
