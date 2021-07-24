using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialService.Management.DTOs.UserDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost("registration")]
        public async Task<IActionResult> Registration([FromQuery] string login)
        {
            var newUser = new UserDto
            {
                
            }
            return Ok();
        }
    }
}
