using Microsoft.AspNetCore.Mvc;
using SocialService.Management.Services.Interfaces;
using System.Threading.Tasks;

namespace SocialService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PopularityController : ControllerBase
    {
        private static readonly int POPULAR_USERS_MAX_COUNT = 150;
        private readonly IPopularityService _popularityService;

        public PopularityController(
            IPopularityService popularityService)
        {
            _popularityService = popularityService;
        }

        [HttpGet("users")]
        public async Task<IActionResult> TopPopularUsers([FromQuery] int count)
        {
            if (count <= 0 || count > POPULAR_USERS_MAX_COUNT)
            {
                return StatusCode(422, $"Count of users must be positive and less than {POPULAR_USERS_MAX_COUNT}");
            }

            var topUsers = await _popularityService.GetTopAsync(count);
            return Ok(topUsers);
        }
    }
}
