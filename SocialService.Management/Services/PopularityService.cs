using SocialService.Management.DTOs.PopularUserDto;
using SocialService.Management.Services.Interfaces;
using SocialService.Repositories.Interfaces;
using SocialService.Storage.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialService.Management.Services
{
    public class PopularityService : IPopularityService
    {
        private readonly IUserRepository _userRepository;

        public PopularityService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IReadOnlyCollection<PopularUserDto>> GetTopAsync(int count = 20)
        {
            var topUsers = await _userRepository.GetPopularAsync(count);
            return Map(topUsers);
        }

        private IReadOnlyCollection<PopularUserDto> Map(IReadOnlyCollection<User> users)
        {
            var userDtos = new List<PopularUserDto>();
            foreach (var user in users)
            {
                userDtos.Add(new PopularUserDto(user.Login, user.Popularity));
            }

            return userDtos;
        }
    }
}
