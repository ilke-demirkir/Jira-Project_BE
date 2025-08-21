using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Project
    {
        public Guid Id { get; set; }

        // Foreign key to Tenant
        public Guid TenantId { get; set; }
        public Tenant Tenant { get; set; }

        public string Name { get; set; }

        // Foreign key to User (Owner)
        public Guid OwnerId { get; set; }
        public ApplicationUser Owner { get; set; }

        // Many-to-many: Members via TenantUser
        public ICollection<TenantUser> Members { get; set; }

        // One-to-many: Tasks
        public ICollection<TaskItem> Tasks { get; set; }
    }
}
