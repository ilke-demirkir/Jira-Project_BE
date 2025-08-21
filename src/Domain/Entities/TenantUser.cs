using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class TenantUser
    {
        Guid TenantId { get; set; }
        Guid UserId { get; set; }
        Tenant Tenant { get; set; }
        User User { get; set; }
        string Role { get; set; }
        bool isActive { get; set; }
        DateTime JoinedAt { get; set; }

    }
}
