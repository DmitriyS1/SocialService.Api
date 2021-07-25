#nullable enable

using SocialService.Storage.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialService.Repositories.Interfaces
{
    public interface IUserRepository
    {
        /// <summary>
        /// Save user to db
        /// </summary>
        /// <param name="user">User entity model</param>
        Task CreateAsync(User user);

        /// <summary>
        /// Get user by login
        /// </summary>
        /// <param name="login">User login</param>
        /// <returns>User entity or null</returns>
        Task<User?> GetAsync(string login);

        /// <summary>
        /// Get users by logins
        /// </summary>
        /// <param name="logins">List of logins</param>
        /// <returns>Collection of users</returns>
        Task<IReadOnlyCollection<User>> GetAsync(List<string> logins);

        /// <summary>
        /// Get top popular users
        /// </summary>
        /// <param name="count">Count of top users</param>
        /// <returns>Requested count of popular users</returns>
        Task<IReadOnlyCollection<User>> GetPopularAsync(int count);

        /// <summary>
        /// Check if user already exists
        /// </summary>
        /// <param name="login">User login</param>
        /// <returns>Is user exists</returns>
        Task<bool> IsExist(string login);
    }
}
