using BookShop.Application.Dto.Authentication;
using BookShop.Domain.Models.Users;

namespace BookShop.Application.Contracts;

public interface IUserService
{
    Task<LoginDto.LoginResult> LoginAsync(LoginDto loginDto);

    Task<RegisterDto.RegisterResult> RegisterAsync(RegisterDto registerDto);

    Task<User> GetByUserNameAsync(string userName);
}