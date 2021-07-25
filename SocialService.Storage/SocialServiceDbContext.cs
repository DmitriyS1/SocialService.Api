using Microsoft.EntityFrameworkCore;
using SocialService.Storage.Entities;

namespace SocialService.Storage
{
    public class SocialServiceDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<UserFollower> UsersFollowers { get; set; }

        public SocialServiceDbContext(DbContextOptions<SocialServiceDbContext> options) 
            : base(options) { }
    }
}
