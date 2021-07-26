using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SocialService.Api.ViewModels.Following;
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
        public async Task<IActionResult> Follow([FromBody] FollowingViewModel model)
        {
            if (string.IsNullOrWhiteSpace(model.UserLogin) || string.IsNullOrWhiteSpace(model.FollowingLogin))
            {
                _logger.LogWarning($"ModelError: userLogin = {model.UserLogin} and followingLogin = {model.FollowingLogin}");
                return BadRequest("Empty login");
            }

            if (model.UserLogin == model.FollowingLogin)
            {
                _logger.LogWarning($"User with login = {model.UserLogin} attempts to follow {model.FollowingLogin}");
                return StatusCode(422, "You can't follow yourself");
            }

            var users = await _userService.GetAsync(new List<string> { model.FollowingLogin, model.UserLogin });
            if (users.Count != USERS_COUNT_FOR_FOLLOW_OPERATION)
            {
                return StatusCode(422, "User you trying to follow not found");
            }

            await _followingService.FollowAsync(
                users.Where(u => u.Login == model.UserLogin).First(),
                users.Where(u => u.Login == model.FollowingLogin).First());

            return StatusCode(201);
        }
    }
}
