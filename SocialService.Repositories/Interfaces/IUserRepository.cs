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

        Task<IReadOnlyCollection<User>> GetAsync(List<string> logins);

        /// <summary>
        /// Check if user already exists
        /// </summary>
        /// <param name="login">User login</param>
        /// <returns>Is user exists</returns>
        Task<bool> IsExist(string login);
    }
}
