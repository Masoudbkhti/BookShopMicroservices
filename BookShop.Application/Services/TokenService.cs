using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BookShop.Application.Services.Authentication;
using BookShop.Domain;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BookShop.Application.Services;

public class TokenService : ITokenService
{
    private readonly SymmetricSecurityKey _key;
    private readonly IConfiguration _configuration;

    public TokenService(IConfiguration configuration)
    {
        _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
        _configuration = configuration;
    }
    public string CreateToken(Domain.Models.Users.User user)
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