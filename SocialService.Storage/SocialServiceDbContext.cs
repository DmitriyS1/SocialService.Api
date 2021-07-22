using Microsoft.EntityFrameworkCore;
using SocialService.Storage.ValueObjects;

namespace SocialService.Storage
{
    public class SocialServiceDbContext : DbContext
    {
        DbSet<User> Users { get; set; }
    }
}
