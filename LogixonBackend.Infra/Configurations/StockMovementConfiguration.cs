using LogixonBackend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogixonBackend.Infra.Configurations
{
    public class StockMovementConfiguration : IEntityTypeConfiguration<StockMovement>
    {
        public void Configure(EntityTypeBuilder<StockMovement> builder)
        {
            builder.ToTable("StockMovements");

            builder.HasKey(sm => sm.Id);

            builder.Property(sm => sm.Type)
                .IsRequired()
                .HasMaxLength(8);
            
            builder.Property(sm => sm.Quantity)
                .IsRequired();

            builder.Property(sm => sm.Reason)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(sm => sm.Notes)
                .HasMaxLength(250);

            builder.Property(sm => sm.CreatedAt)
                .IsRequired();

            builder.HasOne(sm => sm.Product)
                .WithMany(p => p.StockMovements)
                .HasForeignKey(sm => sm.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(sm => sm.User)
                .WithMany(u => u.StockMovements)
                .HasForeignKey(sm => sm.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
