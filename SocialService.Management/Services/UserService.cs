using SocialService.Management.DTOs.UserDto;
using SocialService.Management.Services.Interfaces;
using SocialService.Repositories.Interfaces;
using System.Threading.Tasks;

namespace SocialService.Management.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task AddAsync(UserDto user)
        {
            if (await _userRepository.IsExist(user.Login))
            {
                throw new System.Exception();
            }

            await _userRepository.CreateAsync(
                new Storage.Entities.User 
                { 
                    Id = user.Id,
                    Login = user.Login,
                    Popularity = user.Popularity,
                    CreatedAt = System.DateTime.UtcNow
                });
        }

        public async Task<UserDto> GetAsync(string login)
        {
            var user = await _userRepository.GetAsync(login);
            if (user is null)
            {
                return null;
            }

            return new UserDto(user.Id, user.Login, user.Popularity);
        }
    }
}
