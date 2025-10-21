
using Microsoft.AspNetCore.Mvc;
using PRM392_API.Services.Interface;
using System.Threading.Tasks;

namespace PRM392_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupTaskController : ControllerBase
    {
        private readonly IGroupTaskService _groupTaskService;
        public GroupTaskController(IGroupTaskService groupTaskService)
        {
            _groupTaskService = groupTaskService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var groupTasks = await _groupTaskService.GetAllGroupTasks();
            return Ok(groupTasks);
        }
    }
}
