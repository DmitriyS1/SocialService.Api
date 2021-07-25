using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SocialService.Management.DTOs.UserDto;
using SocialService.Management.Extensions;
using SocialService.Management.Services.Interfaces;
using System.Threading.Tasks;

namespace SocialService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<AuthController> _logger;

        public AuthController(
            IUserService userService,
            ILogger<AuthController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpPost("registration")]
        public async Task<IActionResult> Registration([FromQuery] string login)
        {
            if (!login.IsLoginCorrect())
            {
                _logger.LogError($"Login {login} is incorrect");
                return StatusCode(422, "Login incorrect");
            }

            var newUser = new UserDto(login);
            await _userService.AddAsync(newUser);
            return Ok();
        }
    }
}
