using Microsoft.AspNetCore.Mvc;
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

        [HttpPost("registration")]
        public async Task<IActionResult> Registration([FromQuery] string login)
        {
            if (!login.IsLoginCorrect())
            {
                return StatusCode(422);
            }

            var newUser = new UserDto(login);
            await _userService.AddAsync(newUser);
            return Ok();
        }
    }
}
