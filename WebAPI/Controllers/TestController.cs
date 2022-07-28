using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [Authorize(Roles = "admin")]
        [HttpPost("add")]
        public IActionResult Add()
        {
            return Ok("Add method");
        }


        [Authorize(Roles = "user")]
        [HttpGet("get")]
        public IActionResult Get()
        {
            return Ok("Get method");
        }
    }
}
