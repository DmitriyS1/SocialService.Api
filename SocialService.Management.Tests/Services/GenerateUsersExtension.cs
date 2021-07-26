using SocialService.Storage.Entities;
using System;
using System.Collections.Generic;

namespace SocialService.Management.Tests.Services
{
    public static class GenerateUsersExtension
    {
        public static List<User> GenerateUsers(int count)
        {
            var result = new List<User>();
            if (count <= 0) return result;

            var spaces = "";
            for (var i = count; i > 0; i--)
            {
                result.Add(new User
                {
                    Id = Guid.NewGuid(),
                    CreatedAt = DateTime.UtcNow,
                    Login = $"true{spaces}login",
                    Popularity = 100 * i
                });

                spaces += " ";
            }

            return result;
        }
    }
}
