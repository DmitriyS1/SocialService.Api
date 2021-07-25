using Microsoft.Extensions.Logging;
using SocialService.Management.DTOs.UserDto;
using SocialService.Management.Services.Interfaces;
using SocialService.Repositories.Interfaces;
using SocialService.Storage.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialService.Management.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<UserService> _logger;

        public UserService(
            IUserRepository userRepository,
            ILogger<UserService> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        public async Task AddAsync(UserDto user)
        {
            if (await _userRepository.IsExist(user.Login))
            {
                _logger.LogError($"User with login {user.Login} already exist");
                throw new System.Exception();
            }

            await _userRepository.CreateAsync(
                new User 
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

            return Map(new List<User> { user }).FirstOrDefault();
        }

        public async Task<IReadOnlyCollection<UserDto>> GetAsync(List<string> logins)
        {
            var users = await _userRepository.GetAsync(logins);
            if (users.Count != logins.Count)
            {
                _logger.LogError($"User with id {logins.Where(l => !users.Select(u => u.Login).Contains(l)).FirstOrDefault()} does not exist");
                return null;
            }

            return Map(users);
        }

        private IReadOnlyCollection<UserDto> Map(IReadOnlyCollection<User> users)
        {
            var userDtos = new List<UserDto>();
            foreach(var user in users)
            {
                userDtos.Add(new UserDto(user.Id, user.Login, user.Popularity));
            }

            return userDtos;
        }
    }
}
