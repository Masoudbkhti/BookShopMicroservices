using BookShop.Domain.Models.Profile;
using BookShop.Domain.Models.Users;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace BookShop.Infrastructure.Repositories;

public class UserRepository: IUserRepository
{
    private readonly DataBaseContext _dbContext;

    public UserRepository(DataBaseContext dbContext) 
    {
        _dbContext = dbContext;
    }

    public async Task<Domain.Models.Profile.Profile> GetProfileById(int id)
    {
        return await _dbContext.Profiles.FirstOrDefaultAsync(p => p.UserId == id);
    }
    public async Task<User> GetByUserNameAsync(string userName)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(u=>u.Name==userName);
    }

    public async Task<bool> isExistByUserName(string userName)
    {
        return await _dbContext.Users.AnyAsync(u => u.Name.ToLower() == userName);
    }

    public async Task InserAsync(User user)
    {
        await _dbContext.Users.AddAsync(user);
    }

    public async Task Delete(User user)
    {
        _dbContext.Users.Remove(user);
    }

    public async Task<User> GetById(int id)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
    }
}