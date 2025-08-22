using Application.DTOs;
using MediatR;

namespace Application.Features.Users.Commands
{
    public class RegisterUserCommand : IRequest<UserDto>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string userName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
