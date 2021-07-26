using System;
using System.Threading.Tasks;

namespace SocialService.Repositories.Interfaces
{
    public interface IFollowingRepository
    {
        Task AddFollowingAsync(Guid userId, Guid followingId);

        Task<bool> IsExist(Guid followerId, Guid followingId);
    }
}
