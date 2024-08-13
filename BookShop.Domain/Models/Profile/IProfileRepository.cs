namespace BookShop.Domain.Models.Profile
{
    public interface IProfileRepository
    {
        Task Delete(Profile profile);
        Task<bool> isExist(int userId);   
        Task<Profile> GetByUserId(int id);
    }
}
