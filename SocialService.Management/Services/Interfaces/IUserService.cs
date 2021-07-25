using SocialService.Management.DTOs.UserDto;
using System.Collections.Generic;
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

        /// <summary>
        /// Find user by login
        /// </summary>
        /// <param name="login">User login</param>
        /// <returns>Founded user or null</returns>
        Task<UserDto> GetAsync(string login);

        /// <summary>
        /// Find users by their ids
        /// </summary>
        /// <param name="logins">List of user ids</param>
        /// <returns>Collection of users</returns>
        Task<IReadOnlyCollection<UserDto>> GetAsync(List<string> logins);
    }
}
