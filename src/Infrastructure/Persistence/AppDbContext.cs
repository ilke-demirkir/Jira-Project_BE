using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class AppDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // DbSet'ler
        public DbSet<User> Users { get; set; }

        // OnModelCreating (fluent API, seed data vs.)
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // örn. User entity config
            builder.Entity<User>(entity =>
            {
                entity.Property(u => u.Name).HasMaxLength(50).IsRequired();
                entity.Property(u => u.Surname).HasMaxLength(50).IsRequired();
            });
        }
    }
}
