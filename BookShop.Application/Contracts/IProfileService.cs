using BookShop.Application.Dto.Profile;
using BookShop.Domain.Models.Profile;

namespace BookShop.Application.Contracts
{
    public interface IProfileService
    {
        Task Update(UpdateProfileDto dto);
        Task Delete(int userId);
    }
}
