using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialService.Storage.Entities;

namespace SocialService.Storage.EntityTypeConfiguration
{
    public class UserFollowerDbTypeConfiguration : IEntityTypeConfiguration<UserFollower>
    {
        public void Configure(EntityTypeBuilder<UserFollower> tb)
        {
            tb.ToTable("users_followers");

            tb.HasKey(x => new { x.UserId, x.FollowerId });

            tb.HasOne(x => x.Follower).WithMany(u => u.Followers).HasForeignKey(u => u.FollowerId);
            tb.HasOne(x => x.User).WithMany(u => u.Following).HasForeignKey(u => u.UserId);
        }
    }
}
