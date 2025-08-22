using Application.DTOs;
using MediatR;

namespace Application.Features.Users.Commands
{
    public class LoginUserCommand : IRequest<LoginResponseDto>
    {
        public string Identifier { get; set; }  // hem email hem username ile giriş yapılsın diye. 
        public string Password { get; set; }
    }
}