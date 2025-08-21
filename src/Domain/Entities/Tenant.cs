using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Tenant
    {
        Guid Id { get; set; }
        string Name { get; set; }
        bool isDeleted { get; set; }
        DateTime CreatedAt { get; set; }
        ICollection<TenantUser> Members { get; set; }
    }
}

