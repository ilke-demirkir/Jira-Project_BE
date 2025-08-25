using Application.ServiceInterfaces;
using Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateUserToken(ApplicationUser user)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("name", user.Name),
                new Claim("surname", user.Surname)
            };

            return BuildToken(claims, TimeSpan.FromHours(1)); // user token 1 saatlik
        }

        public string GenerateTenantToken(Tenant tenant)
        {
            var claims = new[]
            {
                new Claim("tenantId", tenant.Id.ToString()),
                new Claim("tenantName", tenant.Name)
            };

            return BuildToken(claims, TimeSpan.FromDays(1)); // tenant tokeni 24 saat geçerli.
        }
        
        //tekrara düşmesin kodlar diye burdan çıkarıyoz
        private string BuildToken(IEnumerable<Claim> claims, TimeSpan lifetime)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.Add(lifetime),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
