using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRM392_API.Services.Interface;
using System.Threading.Tasks;

namespace PRM392_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("GetUserInGroup")]
        public async Task<IActionResult> GetUserInGroup([FromQuery]int groupId)
        {
            var users = await _userService.GetUsersByGroupId(groupId);
            return Ok(users);
        }
    }
}
