using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Business;
using WebAPI.Models;
using WebAPI.Security;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthManager _authManager;

        public AuthController(ITokenGenerator tokenGenerator)
        {
            _authManager = new AuthManager(tokenGenerator);
        }

        [HttpPost("login")]
        public IActionResult Login(UserDto userDto)
        {
            var result=_authManager.Login(userDto);
            if (result==null)
            {
                return Unauthorized();
            }
            return Ok(result);
        }
    }
}
