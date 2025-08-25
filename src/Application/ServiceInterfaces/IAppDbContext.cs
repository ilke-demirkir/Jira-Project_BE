using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.ServiceInterfaces
{
    public interface IAppDbContext //şimdilik kullanmam gerekti böyle yaptım ekleme yapılır daha
    {
        DbSet<Project> Projects { get; }
        DbSet<TaskItem> TaskItems { get; }
        DbSet<Tenant> Tenants { get; }
        DbSet<TenantUser> TenantUsers { get; }
        DbSet<TenantToken> TenantTokens { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
