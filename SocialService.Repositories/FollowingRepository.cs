using SocialService.Repositories.Interfaces;
using SocialService.Storage;
using SocialService.Storage.Entities;
using System;
using System.Threading.Tasks;

namespace SocialService.Repositories
{
    public class FollowingRepository : IFollowingRepository
    {
        private readonly SocialServiceDbContext _dbContext;

        public FollowingRepository(SocialServiceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddFollowing(Guid userId, Guid followingId)
        {
            var following = new UserFollower { UserId = userId, FollowerId = followingId };
            _dbContext.UsersFollowers.Add(following);

            await _dbContext.SaveChangesAsync();
        }
    }
}
