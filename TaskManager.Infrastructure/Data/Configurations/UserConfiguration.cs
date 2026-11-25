using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManager.Core.Entities;
namespace TaskManager.Infrastructure.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(x => x.Id);
            builder.Property(u => u.FullName)
                   .IsRequired()
                   .HasMaxLength(150);
            builder.Property(u => u.Email)
                   .IsRequired()
                   .HasMaxLength(100);
            builder.HasIndex(u => u.Email)
                   .IsUnique();
            builder.Property(u => u.PasswordHash)
                   .IsRequired()
                   .HasMaxLength(256);
            builder.Property(u => u.Skills)
                   .HasMaxLength(500);
            builder.HasMany(u => u.AssignedTasks)
                   .WithOne(t => t.Assignee)
                   .HasForeignKey(u => u.AssigneeId)
                   .OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(u => u.CreatedTasks)
                   .WithOne(c => c.Author)
                   .HasForeignKey(u => u.AuthorId)
                   .OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(u => u.OwnedProjects)
                   .WithOne(o => o.Owner)
                   .HasForeignKey(u => u.OwnerId)
                   .OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(u => u.Comments)
                   .WithOne(c => c.User)
                   .HasForeignKey(u => u.UserId)
                   .OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(u => u.TaskHistories)
                   .WithOne(t => t.User)
                   .HasForeignKey(u => u.UserId)
                   .OnDelete(DeleteBehavior.NoAction);
            builder.Property(u => u.CreatedAt)
                   .IsRequired()
                   .HasColumnType("datetime2")
                   .HasDefaultValueSql("SYSUTCDATETIME()");
            builder.Property(u => u.IsActive)
                   .IsRequired()
                   .HasDefaultValue(true);
        }
    }
}
