using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class TaskItem
    {
        Guid Id { get; set; }
        Guid TenantId { get; set; }
        Tenant Tenant { get; set; } 
        Guid ProjectId { get; set; }
        Project Project { get; set; }
        string Title { get; set; }
        ICollection<User> AssignedUsers { get; set; }
    }
}
