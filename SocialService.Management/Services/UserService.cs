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

        /// <inheritdoc/>
        public async Task AddAsync(UserDto user)
        {
            await _userRepository.CreateAsync(
                new Storage.Entities.User 
                { 
                    Id = user.Id,
                    Login = user.Login,
                    Popularity = user.Popularity,
                    CreatedAt = System.DateTime.UtcNow
                });
        }
    }
}
