using SocialService.Management.DTOs.UserDto;
using System.Threading.Tasks;

namespace SocialService.Management.Services.Interfaces
{
    public interface IUserService
    {
        /// <summary>
        /// Add user to storage
        /// </summary>
        /// <param name="user">New user dto</param>
        Task AddAsync(UserDto user);
    }
}
