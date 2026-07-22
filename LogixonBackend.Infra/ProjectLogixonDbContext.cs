using LogixonBackend.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LogixonBackend.Infra
{
    public class ProjectLogixonDbContext : DbContext
    {
        public ProjectLogixonDbContext(DbContextOptions<ProjectLogixonDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<StockAlert> StockAlerts { get; set; }
        public DbSet<StockMovement> StockMovements { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProjectLogixonDbContext).Assembly);
        }
    }
}
