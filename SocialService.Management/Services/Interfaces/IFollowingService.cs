using SocialService.Management.DTOs.UserDto;
using System.Threading.Tasks;

namespace SocialService.Management.Services.Interfaces
{
    public interface IFollowingService
    {
        Task FollowAsync(UserDto followingUser, UserDto followerUser);
    }
}
