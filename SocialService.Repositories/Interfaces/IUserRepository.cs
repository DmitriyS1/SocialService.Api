using SocialService.Storage.Entities;
using System.Threading.Tasks;

namespace SocialService.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task CreateAsync(User user);

        Task<User> GetAsync(string login);
    }
}
