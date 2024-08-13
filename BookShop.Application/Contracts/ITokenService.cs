namespace BookShop.Application.Services.Authentication;

public interface ITokenService
{
    string CreateToken(Domain.Models.Users.User user);
}