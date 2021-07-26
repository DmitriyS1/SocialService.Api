using Microsoft.Extensions.Logging;
using Moq;
using SocialService.Management.DTOs.UserDto;
using SocialService.Management.Services;
using SocialService.Repositories.Interfaces;
using SocialService.Storage.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace SocialService.Management.Tests.Services.UserServiceTests
{
    public class GetAsyncTests
    {
        private Mock<IUserRepository> _userRepositoryMock;
        private Mock<ILogger<UserService>> _logger;

        public GetAsyncTests()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _logger = new Mock<ILogger<UserService>>();
        }

        [Fact]
        public async Task GetAsync_ShouldReturnUserDto_WhenSearchingByLogin()
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTime.UtcNow,
                Login = "true login",
                Popularity = 100
            };

            _userRepositoryMock
                .Setup(ur => ur.GetAsync(It.IsAny<string>()))
                .Returns(Task.FromResult(user));

            var userService = new UserService(_userRepositoryMock.Object, _logger.Object);
            var result = await userService.GetAsync("ttt");

            Assert.IsType<UserDto>(result);
            Assert.Equal(user.Id, result.Id);
            Assert.Equal(user.Login, result.Login);
            Assert.Equal(user.Popularity, result.Popularity);
        }

        [Fact]
        public async Task GetAsync_ShouldReturnNull_WhenSearchingByNotExistedLogin()
        {
            _userRepositoryMock
                .Setup(ur => ur.GetAsync(It.IsAny<string>()))
                .Returns(Task.FromResult((User)null));

            var userService = new UserService(_userRepositoryMock.Object, _logger.Object);
            var result = await userService.GetAsync("ttt");

            Assert.Null(result);
        }

        [Fact]
        public async Task GetAsync_ShouldReturnUserDtos_WhenSearchingByLogins()
        {
            var logins = new List<string> { "ttt", "asd", "ghj", "erty", "rrr" };
            var users = GenerateUsers(logins.Count);

            _userRepositoryMock
                .Setup(ur => ur.GetAsync(It.IsAny<List<string>>()))
                .Returns(Task.FromResult((IReadOnlyCollection<User>)users));

            var userService = new UserService(_userRepositoryMock.Object, _logger.Object);
            var result = await userService.GetAsync(logins);

            Assert.NotEmpty(result);
            Assert.Equal(users.Count, result.Count);
        }

        [Fact]
        public async Task GetAsync_ShouldReturnEmptyList_WhenSearchingByNotExistedLogins()
        {
            var users = new List<User>();
            _userRepositoryMock
                .Setup(ur => ur.GetAsync(It.IsAny<List<string>>()))
                .Returns(Task.FromResult((IReadOnlyCollection<User>)users));

            var userService = new UserService(_userRepositoryMock.Object, _logger.Object);
            var result = await userService.GetAsync(new List<string> { "ttt", "asd" });

            Assert.Empty(result);
        }

        [Fact]
        public async Task GetAsync_ShouldReturnEmptyList_WhenLoginsCountNotEqualUsersCount()
        {
            var logins = new List<string> { "ttt", "asd", "ghj", "erty", "rrr" };
            var users = GenerateUsers(logins.Count - 2);

            _userRepositoryMock
                .Setup(ur => ur.GetAsync(It.IsAny<List<string>>()))
                .Returns(Task.FromResult((IReadOnlyCollection<User>)users));

            var userService = new UserService(_userRepositoryMock.Object, _logger.Object);
            var result = await userService.GetAsync(logins);

            Assert.Empty(result);
        }

        private List<User> GenerateUsers(int count)
        {
            var result = new List<User>();
            if (count <= 0) return result;

            var spaces = "";
            for (var i = count; i > 0; i--)
            {
                result.Add(new User
                {
                    Id = Guid.NewGuid(),
                    CreatedAt = DateTime.UtcNow,
                    Login = $"true{spaces}login",
                    Popularity = 100 * i
                });

                spaces += " ";
            }

            return result;
        }
    }
}
