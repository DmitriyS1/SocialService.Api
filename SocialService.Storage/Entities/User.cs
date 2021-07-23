using System;

namespace SocialService.Storage.Entities
{
    public class User
    {
        public Guid Id { get; set; }

        public string Login { get; set; }

        public DateTime CreatedAt { get; set; }

        public int Popularity { get; set; }
    }
}
