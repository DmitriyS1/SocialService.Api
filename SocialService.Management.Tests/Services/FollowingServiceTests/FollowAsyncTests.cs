using Microsoft.Extensions.Logging;
using Moq;
using SocialService.Management.DTOs.UserDto;
using SocialService.Management.Services;
using SocialService.Management.Services.Exceptions;
using SocialService.Repositories.Interfaces;
using System;
using System.Threading.Tasks;
using Xunit;

namespace SocialService.Management.Tests.Services.FollowingServiceTests
{
    public class FollowAsyncTests
    {
        private readonly Mock<IFollowingRepository> _followingRepository;
        private readonly Mock<ILogger<FollowingService>> _logger;

        public FollowAsyncTests()
        {
            _followingRepository = new Mock<IFollowingRepository>();
            _logger = new Mock<ILogger<FollowingService>>();
        }

        [Fact]
        public async Task FollowAsync_ShouldNotThrowError_WhenAddNewFollowingEntity()
        {
            _followingRepository
                .Setup(fr => fr.IsExist(It.IsAny<Guid>(), It.IsAny<Guid>()))
                .Returns(Task.FromResult(false));
            _followingRepository
                .Setup(fr => fr.AddFollowingAsync(It.IsAny<Guid>(), It.IsAny<Guid>()))
                .Returns(Task.CompletedTask);

            var followingService = new FollowingService(_followingRepository.Object, _logger.Object);
            await followingService.FollowAsync(new UserDto("str"), new UserDto("log"));

            _followingRepository
                .Verify(fr => fr.IsExist(It.IsAny<Guid>(), It.IsAny<Guid>()),
                Times.Once);
            _followingRepository
                .Verify(fr => fr.AddFollowingAsync(It.IsAny<Guid>(), It.IsAny<Guid>()),
                Times.Once);
        }

        [Fact]
        public async Task FollowAsync_ShouldThrowBusinessException_WhenYouAlreadyFollowing()
        {
            _followingRepository
                .Setup(fr => fr.IsExist(It.IsAny<Guid>(), It.IsAny<Guid>()))
                .Returns(Task.FromResult(true));

            var followingService = new FollowingService(_followingRepository.Object, _logger.Object);

            await Assert.ThrowsAsync<BusinessException>(() => followingService.FollowAsync(new UserDto("str"), new UserDto("log")));
        }
    }
}
