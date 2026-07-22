using LogixonBackend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogixonBackend.Infra.Configurations
{
    public class StockAlertConfiguration : IEntityTypeConfiguration<StockAlert>
    {
        public void Configure(EntityTypeBuilder<StockAlert> builder)
        {
            builder.ToTable("StockAlerts");

            builder.HasKey(sa => sa.Id);

            builder.Property(sa => sa.AlertType)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(sa => sa.AlertDate)
                .IsRequired();

            builder.HasOne(sa => sa.Product)
                .WithMany(p => p.Alerts)
                .HasForeignKey(sa => sa.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
