using Microsoft.Extensions.DependencyInjection;
using SocialService.Management.Services;
using SocialService.Management.Services.Interfaces;
using SocialService.Repositories;
using SocialService.Repositories.Interfaces;

namespace SocialService.Management.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddRepositories(this IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<IFollowingRepository, FollowingRepository>();
        }

        public static void AddServices(this IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddScoped<IUserService, UserService>()
                .AddScoped<IFollowingService, FollowingService>()
                .AddScoped<IPopularityService, PopularityService>();
        }
    }
}
