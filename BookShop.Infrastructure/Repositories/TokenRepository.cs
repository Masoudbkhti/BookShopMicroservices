using BookShop.Domain;
using BookShop.Domain.Models.Users;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BookShop.Infrastructure.Repositories
{
    public class TokenRepository : ITokenRepository
    {
        private readonly SymmetricSecurityKey _key;
        private readonly IConfiguration _configuration;

        public TokenRepository(IConfiguration configuration)
        {
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            _configuration = configuration;
        }
        public string CreateToken(User user)
        {
            var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.Name, user.Name),
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
        };

            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Issuer"],
                claims, expires: DateTime.Now.AddDays(7), signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
