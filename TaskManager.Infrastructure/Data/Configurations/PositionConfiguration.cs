using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManager.Core.Entities;

namespace TaskManager.Infrastructure.Data.Configurations
{
    public class PositionConfiguration : IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> builder)
        {
            builder.ToTable("Positions");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Title)
                   .IsRequired()
                   .HasMaxLength(100);
            builder.HasMany(p => p.Users)
                   .WithOne(u => u.Position)
                   .HasForeignKey(u => u.PositionId)
                   .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
