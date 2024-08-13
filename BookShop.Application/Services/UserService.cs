using BookShop.Application.Contracts;
using BookShop.Application.Dto.Authentication;
using BookShop.Application.Mappers;
using BookShop.Domain;
using BookShop.Domain.Models.Profile;

namespace BookShop.Application.Services;

public class UserService(IUnitOfWork unitOfWork) : IUserService
{
    public async Task<string> LoginAsync(LoginDto loginDto)
    {
        string name = loginDto.Name.ToLower().Trim();
        var user = await unitOfWork.UserRepository.GetByUserNameAsync(name);
        string token = unitOfWork.TokenRepository.CreateToken(user);
        if (user == null) throw new Exception("User or Password is not correct.");
        string hashPassword = loginDto.Password;
        if (user.Password != hashPassword) throw new Exception("User or Password is not correct.");
        return token;
    }
    public async Task<Domain.Models.Users.User> GetByUserNameAsync(string userName)
    {
        string name = userName.ToLower();
        return await unitOfWork.UserRepository.GetByUserNameAsync(name);
    }
    public async Task<Profile> GetProfileById(int id)
    {
        return await unitOfWork.UserRepository.GetProfileById(id);
    }
    public async Task<string> RegisterAsync(RegisterDto registerDto)
    {
        string name = registerDto.Name.ToLower();
        if (await unitOfWork.UserRepository.isExistByUserName(name)) throw new Exception("Please try another Username.");
        Domain.Models.Users.User user = registerDto.RegisterDtoToUser();
        string token = unitOfWork.TokenRepository.CreateToken(user);
        await unitOfWork.UserRepository.InserAsync(user);
        await unitOfWork.Save();
        return token;
    }
}