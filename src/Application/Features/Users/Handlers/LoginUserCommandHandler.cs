using Application.DTOs;
using Application.Features.Users.Commands;
using Application.ServiceInterfaces;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginResponseDto>
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ITokenService _tokenService;

    public LoginUserCommandHandler(UserManager<ApplicationUser> userManager, ITokenService tokenService)
    {
        _userManager = userManager;
        _tokenService = tokenService;
    }

    public async Task<LoginResponseDto> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        ApplicationUser user = null;

        if (request.Identifier.Contains("@"))
            user = await _userManager.FindByEmailAsync(request.Identifier);
        else
            user = await _userManager.FindByNameAsync(request.Identifier);

        if (user == null)
            throw new UnauthorizedAccessException("Invalid credentials.");


        if (user == null)
            throw new UnauthorizedAccessException("Invalid credentials.");

        var passwordValid = await _userManager.CheckPasswordAsync(user, request.Password);

        if (!passwordValid)
            throw new UnauthorizedAccessException("Invalid credentials.");

        var token = _tokenService.GenerateToken(user);

        var userDto = new UserDto
        {
            Id = user.Id,
            Email = user.Email,
            userName = user.UserName,
            Name = user.Name,
            Surname = user.Surname
        };

        return new LoginResponseDto
        {
            Token = token,
            User = userDto
        };
    }

}