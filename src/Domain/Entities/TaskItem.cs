using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class TaskItem
    {
        public Guid Id { get; set; }
        public Guid TenantId { get; set; }
        public Tenant Tenant { get; set; } 

        public Guid ProjectId { get; set; }
        public Project Project { get; set; }

        public string Title { get; set; }

        // Many-to-many: Assigned users via TenantUser or a dedicated join entity
        public ICollection<User> AssignedUsers { get; set; }
    }
}
