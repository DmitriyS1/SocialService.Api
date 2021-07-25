using SocialService.Management.DTOs.UserDto;
using SocialService.Management.Services.Interfaces;
using System.Threading.Tasks;

namespace SocialService.Management.Services
{
    public class FollowingService : IFollowingService
    {
        public async Task FollowAsync(UserDto followingUser, UserDto followerUser)
        {
            throw new System.NotImplementedException();
        }
    }
}
