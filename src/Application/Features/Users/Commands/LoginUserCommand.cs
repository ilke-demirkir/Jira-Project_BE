using Application.DTOs;
using MediatR;

namespace Application.Features.Users.Commands
{
    public class LoginUserCommand : IRequest<LoginResponseDto>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
