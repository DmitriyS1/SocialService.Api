using Microsoft.AspNetCore.Mvc;
using SocialService.Management.Services.Interfaces;
using System.Threading.Tasks;

namespace SocialService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PopularityController : ControllerBase
    {
        private readonly IPopularityService _popularityService;

        public PopularityController(
            IPopularityService popularityService)
        {
            _popularityService = popularityService;
        }

        [HttpGet("users")]
        public async Task<IActionResult> TopPopularUsers([FromQuery] int count)
        {
            if (count <= 0)
            {
                return StatusCode(422, "Count of users must be positive");
            }

            var topUsers = await _popularityService.GetTopAsync(count);
            return Ok(topUsers);
        }
    }
}
