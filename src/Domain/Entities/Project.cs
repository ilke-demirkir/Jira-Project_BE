using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Project
    {
        Guid Id { get; set; }
        Guid TenantId { get; set; }
        public Tenant Tenant { get; set; }
        string Name { get; set; }
        Guid OwnerId { get; set; }
        ICollection<User> Member { get; set; }
        ICollection<TaskItem> Tasks { get; set; }
    }
}
