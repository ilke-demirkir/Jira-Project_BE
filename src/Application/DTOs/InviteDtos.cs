using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class CreateInviteDto
    {
        public Guid TenantId { get; set; }
    }

    public class AcceptInviteDto
    {
        public string Token { get; set; }
    }

    public class InviteResponseDto
    {
        public string InviteLink { get; set; }
    }


}
