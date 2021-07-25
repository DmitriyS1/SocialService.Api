using Microsoft.EntityFrameworkCore;
using SocialService.Repositories.Interfaces;
using SocialService.Storage;
using SocialService.Storage.Entities;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<User> GetAsync(string login)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Login == login);

            return user;
        }

        public async Task<IReadOnlyCollection<User>> GetAsync(List<string> logins)
        {
            var users = await _dbContext.Users
                .Where(u => logins.Contains(u.Login))
                .ToListAsync();

            return users;
        }

        public async Task<bool> IsExist(string login)
        {
            return await _dbContext.Users.AnyAsync(x => x.Login == login);
        }
    }
}
