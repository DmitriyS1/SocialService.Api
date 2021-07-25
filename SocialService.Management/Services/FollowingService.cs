using Microsoft.Extensions.Logging;
using SocialService.Management.DTOs.UserDto;
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

        public async Task FollowAsync(UserDto followingUser, UserDto followerUser)
        {
            throw new System.NotImplementedException();
        }
    }
}
