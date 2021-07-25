using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SocialService.Management.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FollowingController : ControllerBase
    {
        private static readonly int USERS_COUNT_FOR_FOLLOW_OPERATION = 2;

        private readonly IUserService _userService;
        private readonly IFollowingService _followingService;
        private readonly ILogger<FollowingController> _logger;

        public FollowingController(
            IUserService userService,
            IFollowingService followingService,
            ILogger<FollowingController> logger)
        {
            _userService = userService;
            _followingService = followingService;
            _logger = logger;
        }

        [HttpPost("followers")]
        public async Task<IActionResult> Follow([FromBody] string userLogin, [FromBody] string followingLogin)
        {
            if (userLogin == followingLogin)
            {
                _logger.LogWarning($"User with login = {userLogin} attempts to follow {followingLogin}");
                return StatusCode(422, "You can't follow yourself");
            }

            var users = await _userService.GetAsync(new List<string> { followingLogin, userLogin });
            if (users.Count != USERS_COUNT_FOR_FOLLOW_OPERATION)
            {
                return StatusCode(422, "User you trying to follow not found");
            }

            await _followingService.FollowAsync(
                users.Where(u => u.Login == userLogin).First(),
                users.Where(u => u.Login == followingLogin).First());

            return Ok();
        }
    }
}
