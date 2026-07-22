using LogixonBackend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogixonBackend.Infra.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Email)
                   .IsRequired()
                   .HasMaxLength(256);

            builder.Property(u => u.PasswordHash)
                   .IsRequired();

            builder.Property(u => u.FullName)
                   .HasMaxLength(200);

            builder.Property(u => u.CreatedAt)
                   .IsRequired();

            builder.Property(u => u.IsActive)
                   .IsRequired();
        }
    }
}
