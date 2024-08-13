using BookShop.Domain.Models.Profile;

namespace BookShop.Domain.Models.Users;

public interface IUserRepository
{
    Task<User> GetByUserNameAsync(string userName);
    Task<bool> isExistByUserName(string userName);
    Task InserAsync(User user);
    Task<Profile.Profile> GetProfileById(int id);
    Task Delete(User user); 
    Task<User> GetById(int id);
}