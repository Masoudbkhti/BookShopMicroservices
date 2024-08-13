using BookShop.Application.Dto.Profile;
using BookShop.Domain.Models.Profile;

namespace BookShop.Application.Mappers
{
    public static class ProfileMapper
    {
        public static Profile UpdateProfileDtoToProfile(UpdateProfileDto dto) => new Profile()
        {
            Address = dto.Address,
        };
    }
}
