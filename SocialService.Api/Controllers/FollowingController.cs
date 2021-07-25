using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SocialService.Management.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FollowingController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<FollowingController> _logger; 

        public async Task<IActionResult> Follow([FromBody] string followingLogin, [FromBody] string followerLogin)
        {
            if (followingLogin == followerLogin)
            {
                _logger.LogWarning($"User with login = {followingLogin} trying to follow {followerLogin}");
                return StatusCode(422, "You can't follow yourself");
            }


        }
    }
}
