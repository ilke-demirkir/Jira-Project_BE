using Domain.Entities;
using System;

namespace Application.ServiceInterfaces
{
    public interface IInviteService
    {
        string CreateInvite(Guid tenantId);
        Tenant AcceptInvite(string token);
    }
}
