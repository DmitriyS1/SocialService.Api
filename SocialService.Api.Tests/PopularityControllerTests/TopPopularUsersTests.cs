using Microsoft.AspNetCore.Mvc;
using Moq;
using SocialService.Api.Controllers;
using SocialService.Management.DTOs.PopularUserDto;
using SocialService.Management.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace SocialService.Api.Tests.PopularityControllerTests
{
    public class TopPopularUsersTests
    {
        private readonly Mock<IPopularityService> _popularityService;

        public TopPopularUsersTests()
        {
            _popularityService = new Mock<IPopularityService>();
        }

        [Fact]
        public async Task TopPopularUsers_ShouldReturnPopularUsers()
        {
            var users = new List<PopularUserDto>
            {
                new PopularUserDto("first", 150),
                new PopularUserDto("second", 133),
                new PopularUserDto("third", 121),
                new PopularUserDto("fourth", 100)
            };
            _popularityService
                .Setup(ps => ps.GetTopAsync(It.IsAny<int>()))
                .Returns(Task.FromResult((IReadOnlyCollection<PopularUserDto>)users));

            var popularityController = new PopularityController(_popularityService.Object);
            var result = await popularityController.TopPopularUsers(4) as ObjectResult;

            Assert.Equal(200, result.StatusCode);
            Assert.NotEmpty((IReadOnlyCollection<PopularUserDto>)result.Value);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-10)]
        [InlineData(200)]
        public async Task TopPopularUsers_ShouldReturnUnprocessibleEntity_WhenCountIncorrect(int count)
        {
            var popularityController = new PopularityController(_popularityService.Object);
            var result = await popularityController.TopPopularUsers(count) as ObjectResult;

            Assert.Equal(422, result.StatusCode);
        }
    }
}
