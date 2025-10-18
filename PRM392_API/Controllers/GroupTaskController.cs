
using Microsoft.AspNetCore.Mvc;
using PRM392_API.Services.Interface;

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
        public IActionResult Get()
        {
            var groupTasks = _groupTaskService.GetAllGroupTasks();
            return Ok(groupTasks);
        }
    }
}
