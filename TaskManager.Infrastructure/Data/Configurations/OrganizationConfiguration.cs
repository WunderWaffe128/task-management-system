using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManager.Core.Entities;
namespace TaskManager.Infrastructure.Data.Configurations
{
    public class OrganizationConfiguration : IEntityTypeConfiguration<Organization>
    {
        public void Configure(EntityTypeBuilder<Organization> builder)
        {
            builder.ToTable("Organization");
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Name)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(o => o.CreateDate)
                 .HasColumnType("datetime")
                 .HasDefaultValueSql("GETDATE()");
            builder.HasMany(o => o.Users)
                   .WithOne(u => u.Organization)
                   .HasForeignKey(u => u.OrganizationId)
                   .OnDelete(DeleteBehavior.SetNull);
            builder.HasMany(o => o.Projects)
                   .WithOne(p => p.Organization)
                   .HasForeignKey(p => p.OrganizationId)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
