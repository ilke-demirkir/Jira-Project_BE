using Application.ServiceInterfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infrastructure.Services
{
    public class InviteService : IInviteService
    {
        private readonly ITokenService _tokenService;
        private readonly AppDbContext _db;

        public InviteService(ITokenService tokenService, AppDbContext db)
        {
            _tokenService = tokenService;
            _db = db;
        }

        public string CreateInvite(Guid tenantId)
        {
            var tenant = _db.Tenant.Find(tenantId);
            if (tenant == null)
                throw new Exception("Tenant bulunamadı");

            var rawLink = _tokenService.GenerateTenantToken(tenant);

            var tenantToken = new TenantToken
            {
                TenantId = tenantId,
                Tenant = tenant,
                Link = rawLink
            };

            _db.tenantTokens.Add(tenantToken);
            _db.SaveChanges();

            return $"https://app.example.com/accept-invite?token={rawLink}";
        }

        public Tenant AcceptInvite(string token)
        {
            var tenantToken = _db.tenantTokens
                .Include(t => t.Tenant)
                .FirstOrDefault(t => t.Link == token);

            if (tenantToken == null)
                throw new Exception("Geçersiz token");

            _db.tenantTokens.Remove(tenantToken);
            _db.SaveChanges();

            return tenantToken.Tenant;
        }
    }
}
