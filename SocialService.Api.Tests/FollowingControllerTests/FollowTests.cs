using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using SocialService.Api.Controllers;
using SocialService.Api.ViewModels.Following;
using SocialService.Management.DTOs.UserDto;
using SocialService.Management.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace SocialService.Api.Tests.FollowingControllerTests
{
    public class FollowTests
    {
        private readonly Mock<IUserService> _userService;
        private readonly Mock<IFollowingService> _followingService;
        private readonly Mock<ILogger<FollowingController>> _logger;

        public FollowTests()
        {
            _userService = new Mock<IUserService>();
            _followingService = new Mock<IFollowingService>();
            _logger = new Mock<ILogger<FollowingController>>();
        }

        [Fact]
        public async Task Follow_ShouldReturn201_WhenModelValid()
        {
            var model = new FollowingViewModel
            {
                UserLogin = "user",
                FollowingLogin = "following"
            };
            var users = new List<UserDto>
            {
                new UserDto(model.UserLogin),
                new UserDto(model.FollowingLogin)
            };
            _userService
                .Setup(us => us.GetAsync(It.IsAny<List<string>>()))
                .Returns(Task.FromResult((IReadOnlyCollection<UserDto>)users));
            _followingService
                .Setup(fs => fs.FollowAsync(It.IsAny<UserDto>(), It.IsAny<UserDto>()))
                .Returns(Task.CompletedTask);

            var controller = new FollowingController(
                _userService.Object,
                _followingService.Object,
                _logger.Object);
            var result = await controller.Follow(model)as StatusCodeResult;

            Assert.Equal(201, result.StatusCode);
        }

        [Fact]
        public async Task Follow_ShouldReturnBadRequest_WhenUserLoginIsEmpty()
        {
            var model = new FollowingViewModel
            {
                UserLogin = "",
                FollowingLogin = "asf"
            };

            var controller = new FollowingController(
                _userService.Object,
                _followingService.Object,
                _logger.Object);
            var result = await controller.Follow(model) as ObjectResult;

            Assert.Equal(400, result.StatusCode);
        }

        [Fact]
        public async Task Follow_ShouldReturnUnprocessibleEntity_WhenLoginsAreEqual()
        {
            var model = new FollowingViewModel
            {
                UserLogin = "asf",
                FollowingLogin = "asf"
            };

            var controller = new FollowingController(
                _userService.Object,
                _followingService.Object,
                _logger.Object);
            var result = await controller.Follow(model) as ObjectResult;

            Assert.Equal(422, result.StatusCode);
        }

        [Fact]
        public async Task Follow_ShouldReturnUnprocessibleEntity_WhenUserNotFound()
        {
            var model = new FollowingViewModel
            {
                UserLogin = "asf",
                FollowingLogin = "abs"
            };
            var users = new List<UserDto>
            {
                new UserDto(model.FollowingLogin)
            };
            _userService
                .Setup(us => us.GetAsync(It.IsAny<List<string>>()))
                .Returns(Task.FromResult((IReadOnlyCollection<UserDto>)users));
            _followingService
                .Setup(fs => fs.FollowAsync(It.IsAny<UserDto>(), It.IsAny<UserDto>()))
                .Returns(Task.CompletedTask);

            var controller = new FollowingController(
                _userService.Object,
                _followingService.Object,
                _logger.Object);
            var result = await controller.Follow(model) as ObjectResult;

            Assert.Equal(422, result.StatusCode);
        }
    }
}
