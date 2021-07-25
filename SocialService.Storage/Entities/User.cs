using System;
using System.Collections.Generic;

namespace SocialService.Storage.Entities
{
    public class User
    {
        public Guid Id { get; set; }

        public string Login { get; set; }

        public DateTime CreatedAt { get; set; }

        public int Popularity { get; set; }

        public ICollection<UserFollower> Followers { get; set; }

        public ICollection<UserFollower> Following { get; set; }
    }
}
