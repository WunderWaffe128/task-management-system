using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManager.Core.Entities;

namespace TaskManager.Infrastructure.Data.Configurations
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Title)
                   .IsRequired()
                   .HasMaxLength(150);
            builder.HasMany(p => p.Tasks)
                   .WithOne(t => t.Project)
                   .HasForeignKey(p => p.ProjectId)
                   .OnDelete(DeleteBehavior.Cascade);
            builder.Property(p => p.Description)
                   .IsRequired();
            builder.Property(p => p.Status)
                   .IsRequired()
                   .HasMaxLength(50)
                   .HasDefaultValue("Active");
            builder.Property(p => p.CreatedDate)
                   .HasColumnType("datetime")
                   .HasDefaultValueSql("GETDATE()");
            builder.ToTable("Project", table =>
            {
                table.HasCheckConstraint(
                    "CK_Project_Status",
                    "[Status] IN ('Planning','Active','On Hold','Completed','Cancelled')");
            });
            builder.Property(p => p.OrganizationId)
                   .IsRequired();
        }
    }
}
