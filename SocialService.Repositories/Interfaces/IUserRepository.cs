using SocialService.Storage.Entities;
using System.Threading.Tasks;

namespace SocialService.Repositories.Interfaces
{
    interface IUserRepository
    {
        Task CreateAsync(User user);
    }
}
