using Microsoft.EntityFrameworkCore;
using SocialService.Storage.Entities;

namespace SocialService.Storage
{
    public class SocialServiceDbContext : DbContext
    {
        DbSet<User> Users { get; set; }
    }
}
