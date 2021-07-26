using Microsoft.Extensions.Logging;
using SocialService.Management.DTOs.UserDto;
using SocialService.Management.Services.Exceptions;
using SocialService.Management.Services.Interfaces;
using SocialService.Repositories.Interfaces;
using System.Threading.Tasks;

namespace SocialService.Management.Services
{
    public class FollowingService : IFollowingService
    {
        private readonly IFollowingRepository _followingRepository;
        private readonly ILogger<FollowingService> _logger;

        public FollowingService(
            IFollowingRepository followingRepository,
            ILogger<FollowingService> logger)
        {
            _followingRepository = followingRepository;
            _logger = logger;
        }

        public async Task FollowAsync(UserDto follower, UserDto following)
        {
            if (await _followingRepository.IsExist(follower.Id, following.Id))
            {
                _logger.LogError($"Following connection between {follower.Id} and {following.Id} already exist");
                throw new BusinessException(200, "You already following this user");
            }

            await _followingRepository.AddFollowingAsync(follower.Id, following.Id);
        }
    }
}
