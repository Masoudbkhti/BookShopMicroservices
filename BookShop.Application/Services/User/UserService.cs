using BookShop.Application.Contracts;
using BookShop.Application.Dto.Authentication;
using BookShop.Application.Mappers;
using BookShop.Domain;

namespace BookShop.Application.Services.User;

public class UserService(IUnitOfWork unitOfWork): IUserService
{
    public async Task<LoginDto.LoginResult> LoginAsync(LoginDto loginDto)
    {
        string name = loginDto.Name.ToLower().Trim();
        var user = await unitOfWork.UserRepository.GetByUserNameAsync(name);
        if (user == null)
        {
            return LoginDto.LoginResult.Error;
        }

        string hashPassword = loginDto.Password;
        if (user.Password != hashPassword)
        {
            return LoginDto.LoginResult.Error;
        }

        return LoginDto.LoginResult.Success;

    }

    public async Task<Domain.Models.Users.User> GetByUserNameAsync(string userName)
    {
        string name = userName.ToLower().Trim();
        return await unitOfWork.UserRepository.GetByUserNameAsync(userName);
    }
    
    public async Task<RegisterDto.RegisterResult> RegisterAsync(RegisterDto registerDto)
    {
        if (await unitOfWork.UserRepository.DupplicatedUserAsync(registerDto.Name))
        {
            return RegisterDto.RegisterResult.DupplicateUser;
        }

        Domain.Models.Users.User user = ProductMapper.RegisterDtoToUser(registerDto);

        await unitOfWork.UserRepository.InserAsync(user);
        await unitOfWork.Save();

        return RegisterDto.RegisterResult.Success;

    }
}