using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class TenantUser
    {
        public Guid TenantId { get; set; }
        public Tenant Tenant { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }

        public string Role { get; set; }
        public bool isActive { get; set; }
        public DateTime JoinedAt { get; set; }
    }
}
