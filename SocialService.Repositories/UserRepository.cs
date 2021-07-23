using SocialService.Repositories.Interfaces;
using SocialService.Storage;
using SocialService.Storage.Entities;
using System.Threading.Tasks;

namespace SocialService.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SocialServiceDbContext _dbContext;

        public UserRepository(SocialServiceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAsync(User user)
        {
            _dbContext.Users.Add(user);

            await _dbContext.SaveChangesAsync();
        }
    }
}
