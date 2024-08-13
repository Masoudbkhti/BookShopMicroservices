using BookShop.Application.Contracts;
using BookShop.Application.Dto.Profile;
using BookShop.Application.Mappers;
using BookShop.Domain;

namespace BookShop.Application.Services
{
    public class ProfileService(IUnitOfWork unitOfWork) : IProfileService
    {
        public async Task Delete(int userId)
        {
            var profile = await unitOfWork.ProfileRepository.GetByUserId(userId);
            var user = await unitOfWork.UserRepository.GetById(userId);
            if (userId <= 0 || profile == null || user == null) throw new Exception("Please enter valid id.");
            await unitOfWork.ProfileRepository.Delete(profile);
            await unitOfWork.UserRepository.Delete(user);
            await unitOfWork.Save();
        }
        public async Task Update(UpdateProfileDto dto)
        {
            bool isExist = await unitOfWork.ProfileRepository.isExist(dto.userId);
            if (dto.userId <= 0 || !isExist) throw new Exception("Please enter valid id.");
            var profile = await unitOfWork.ProfileRepository.GetByUserId(dto.userId);
            profile.Address = dto.Address;
            await unitOfWork.Save();
        }
    }
}
