using BookShop.Application.Dto.Authentication;
using BookShop.Domain.Models.Profile;
using BookShop.Domain.Models.Users;

namespace BookShop.Application.Contracts;

public interface IUserService
{
    Task<string> LoginAsync(LoginDto loginDto);

    Task<string> RegisterAsync(RegisterDto registerDto);

    Task<User> GetByUserNameAsync(string userName);

    Task<Domain.Models.Profile.Profile> GetProfileById(int id);
}