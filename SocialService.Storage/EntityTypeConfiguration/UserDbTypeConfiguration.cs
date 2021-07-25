using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialService.Storage.Entities;

namespace SocialService.Storage.EntityTypeConfiguration
{
    public class UserDbTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> tb)
        {
            tb.ToTable("users");
            tb.Property(x => x.Login).HasMaxLength(64).IsRequired();

            tb.HasKey(x => x.Id);
            tb.HasIndex(x => x.Login);
        }
    }
}
