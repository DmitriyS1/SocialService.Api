using System;

namespace SocialService.Management.DTOs.UserDto
{
    public class UserDto
    {
        public UserDto(
            Guid id,
            string login,
            int popularity)
        {
            Id = id;
            Login = login;
            Popularity = popularity;
        }

        public UserDto(string login)
        {
            Id = Guid.NewGuid();
            Login = login;
            Popularity = 0;
        }

        public Guid Id { get; }

        public string Login { get; }

        public int Popularity { get; }
    }
}
