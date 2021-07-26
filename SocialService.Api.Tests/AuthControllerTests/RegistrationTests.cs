using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using SocialService.Api.Controllers;
using SocialService.Management.DTOs.UserDto;
using SocialService.Management.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SocialService.Api.Tests.AuthControllerTests
{
    public class RegistrationTests
    {
        private readonly Mock<IUserService> _userService;
        private readonly Mock<ILogger<AuthController>> _logger;

        public RegistrationTests()
        {
            _userService = new Mock<IUserService>();
            _logger = new Mock<ILogger<AuthController>>();
        }

        [Fact]
        public async Task Registration_ShouldReturn201_WhenLoginCorrect()
        {
            var login = "test login";
            _userService
                .Setup(us => us.AddAsync(It.IsAny<UserDto>()))
                .Returns(Task.CompletedTask);

            var authController = new AuthController(_userService.Object, _logger.Object);
            var result = (await authController.Registration(login)) as StatusCodeResult;

            Assert.Equal(201, result.StatusCode);
        }

        [Fact]
        public async Task Registration_ShouldReturn422_WhenLoginIncorrect()
        {
            var login = "123";
            
            var authController = new AuthController(_userService.Object, _logger.Object);
            var result = (await authController.Registration(login)) as ObjectResult;

            Assert.Equal(422, result.StatusCode);
        }
    }
}
