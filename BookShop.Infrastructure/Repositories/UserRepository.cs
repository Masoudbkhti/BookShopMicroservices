using BookShop.Domain.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Infrastructure.Repositories;

public class UserRepository: IUserRepository
{
    private readonly DataBaseContext _dbContext;

    public UserRepository(DataBaseContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<User> GetByUserNameAsync(string userName)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(u=>u.Name==userName);
    }

    public async Task<bool> DupplicatedUserAsync(string userName)
    {
        return await _dbContext.Users.AnyAsync(u => u.Name == userName);
    }

    public async Task InserAsync(User user)
    {
        await _dbContext.Users.AddAsync(user);
    }
}