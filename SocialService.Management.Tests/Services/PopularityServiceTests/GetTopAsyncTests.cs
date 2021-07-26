using Moq;
using SocialService.Repositories.Interfaces;
using SocialService.Management.Services;
using SocialService.Storage.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace SocialService.Management.Tests.Services.PopularityServiceTests
{
    public class GetTopAsyncTests
    {
        private readonly Mock<IUserRepository> _userRepository;

        public GetTopAsyncTests()
        {
            _userRepository = new Mock<IUserRepository>();
        }

        [Theory]
        [InlineData(5)]
        [InlineData(0)]
        [InlineData(20)]
        public async Task GetTopAsync_ShouldReturnPopularUserDtos(int usersCount)
        {
            var popUsers = GenerateUsersExtension.GenerateUsers(usersCount);
            _userRepository
                .Setup(ur => ur.GetPopularAsync(It.IsAny<int>()))
                .Returns(Task.FromResult((IReadOnlyCollection<User>)popUsers));

            var popService = new PopularityService(_userRepository.Object);

            var result = await popService.GetTopAsync(usersCount);

            if (usersCount != 0)
            {
                Assert.NotEmpty(result);
                Assert.Equal(popUsers.Count, result.Count);
            }
            else
            {
                Assert.Empty(result);
            }
        }
    }
}
