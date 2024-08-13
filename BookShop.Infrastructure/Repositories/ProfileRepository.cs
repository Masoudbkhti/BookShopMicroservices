using BookShop.Domain.Models.Profile;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Infrastructure.Repositories
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly DataBaseContext _dataBaseContext;
        public ProfileRepository(DataBaseContext dataBaseContext) 
        {
            _dataBaseContext = dataBaseContext;
        }

        public async Task Delete(Profile profile)
        {
            _dataBaseContext.Remove(profile);
        }

        public async Task<Profile> GetByUserId(int id)
        {
            return await _dataBaseContext.Profiles.FirstOrDefaultAsync(p => p.UserId == id);
        }

        public async Task<bool> isExist(int userId)
        {
            return await _dataBaseContext.Profiles.AnyAsync(p => p.UserId == userId);
        }
    }
}
