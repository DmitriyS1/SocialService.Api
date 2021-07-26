using Microsoft.Extensions.Logging;
using Moq;
using SocialService.Management.DTOs.UserDto;
using SocialService.Management.Services;
using SocialService.Management.Services.Exceptions;
using SocialService.Repositories.Interfaces;
using SocialService.Storage.Entities;
using System.Threading.Tasks;
using Xunit;

namespace SocialService.Management.Tests.Services.UserServiceTests
{
    public class AddAsyncTests
    {
        private Mock<IUserRepository> _userRepositoryMock;
        private Mock<ILogger<UserService>> _logger;

        public AddAsyncTests()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _logger = new Mock<ILogger<UserService>>();
        }

        [Fact]
        public async Task AddAsync_ShouldNotThrowError_WhenAddingUser()
        {
            _userRepositoryMock
                .Setup(ur => ur.IsExist(It.IsAny<string>()))
                .Returns(Task.FromResult(false));
            _userRepositoryMock
                .Setup(ur => ur.CreateAsync(It.IsAny<User>()))
                .Returns(Task.CompletedTask);
            
            var user = new UserDto("str");
            var userService = new UserService(_userRepositoryMock.Object, _logger.Object);
            
            await userService.AddAsync(user);

            _userRepositoryMock
                .Verify(
                    ur => ur.IsExist(It.Is<string>(login => login == user.Login)),
                    Times.Once);
            _userRepositoryMock
                .Verify(
                    ur => ur.CreateAsync(It.IsAny<User>()),
                    Times.Once);
        }

        [Fact]
        public async Task AddAsync_ShouldThrowBusinessException_WhenAddingExistedUser()
        {
            _userRepositoryMock
                .Setup(ur => ur.IsExist(It.IsAny<string>()))
                .Returns(Task.FromResult(true));

            var user = new UserDto("str");
            var userService = new UserService(_userRepositoryMock.Object, _logger.Object);

            await Assert.ThrowsAsync<BusinessException>(() => userService.AddAsync(user));
        }
    }
}
