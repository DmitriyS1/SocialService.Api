using System;

namespace SocialService.Storage.Entities
{
    public class UserFollower
    {
        public Guid UserId { get; set; }

        public Guid FollowerId { get; set; }
    }
}
