using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class AppDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // DbSet'ler
        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<TaskItem> TaskItems { get; set; }
        public DbSet<Tenant> Tenant { get; set; }   
        public DbSet<TenantUser> tenantUsers { get; set; }

        // OnModelCreating (fluent API, seed data vs.)
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // örn. User entity config
            builder.Entity<ApplicationUser>(entity =>
            {
                entity.Property(u => u.Name).HasMaxLength(50).IsRequired();
                entity.Property(u => u.Surname).HasMaxLength(50).IsRequired();
            });
        }
    }
}
