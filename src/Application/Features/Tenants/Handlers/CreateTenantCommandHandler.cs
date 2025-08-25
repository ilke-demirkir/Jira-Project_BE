using Application.Features.Tenants.Commands;
using Domain.Entities;
using Domain.RepoInterfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;

public class CreateTenantCommandHandler : IRequestHandler<CreateTenantCommand, Guid>
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ITenantRepository _tenantRepository;

    public CreateTenantCommandHandler(UserManager<ApplicationUser> userManager, ITenantRepository tenantRepository)
    {
        _userManager = userManager;
        _tenantRepository = tenantRepository;
    }

    public async Task<Guid> Handle(CreateTenantCommand request, CancellationToken cancellationToken)
    {
        var tenant = new Tenant
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            CreatedAt = DateTime.UtcNow,
            isDeleted = false
        };

        // Burada Members ekleniyor
        tenant.Members = new List<TenantUser>
    {
        new TenantUser
        {
            UserId = request.UserId,
            Role = "Admin",
            isActive = true,
            JoinedAt = DateTime.UtcNow
        }
    };

        await _tenantRepository.AddAsync(tenant, cancellationToken);
        await _tenantRepository.SaveChangesAsync(cancellationToken);

        return tenant.Id;
    }

}
