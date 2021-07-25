using System;
using System.Threading.Tasks;

namespace SocialService.Repositories.Interfaces
{
    public interface IFollowingRepository
    {
        Task AddFollowing(Guid userId, Guid followingId);
    }
}
