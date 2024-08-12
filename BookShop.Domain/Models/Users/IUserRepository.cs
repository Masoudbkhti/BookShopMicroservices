namespace BookShop.Domain.Models.Users;

public interface IUserRepository
{
    Task<User> GetByUserNameAsync(string userName);

    Task<bool> DupplicatedUserAsync(string userName);

    Task InserAsync(User user);
    
}