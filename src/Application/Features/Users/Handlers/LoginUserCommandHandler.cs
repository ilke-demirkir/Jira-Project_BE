using Application.Features.Users.Commands;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Application.ServiceInterfaces; // ITokenService burada olacak

namespace Application.Features.Users.Handlers
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, string>
    {
        private readonly UserManager<User> _userManager;
        private readonly ITokenService _tokenService;

        public LoginUserCommandHandler(UserManager<User> userManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }

        public async Task<string> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user == null)
                throw new Exception("Kullanıcı bulunamadı.");

            var isPasswordValid = await _userManager.CheckPasswordAsync(user, request.Password);

            if (!isPasswordValid)
                throw new Exception("Şifre yanlış.");

            var token = _tokenService.GenerateToken(user);

            return token;
        }
    }
}
