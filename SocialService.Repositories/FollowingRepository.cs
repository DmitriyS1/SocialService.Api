using Microsoft.EntityFrameworkCore;
using SocialService.Repositories.Interfaces;
using SocialService.Storage;
using SocialService.Storage.Entities;
using System;
using System.Linq;
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
            var following = new UserFollower { UserId = followingId, FollowerId = userId };
            _dbContext.UsersFollowers.Add(following);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> IsExist(Guid followerId, Guid followingId) 
            => await _dbContext.UsersFollowers
                .Where(uf => uf.UserId == followingId && uf.FollowerId == followerId)
                .AnyAsync();
    }
}
