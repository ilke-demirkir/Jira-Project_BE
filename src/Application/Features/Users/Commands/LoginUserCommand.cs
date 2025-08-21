using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Application.Features.Users.Commands
{
    public class LoginUserCommand : IRequest<string> // string token döndürüyor JWT için yazacam
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
