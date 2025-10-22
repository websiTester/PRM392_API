
using Microsoft.AspNetCore.Mvc;
using PRM392_API.DTOs.GroupTask;
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
        public async Task<IActionResult> Get([FromQuery] int assignmentId, [FromQuery] int groupId)
        {
            var groupTasks = await _groupTaskService.GetAllGroupTasks(assignmentId, groupId);
            return Ok(groupTasks);
        }

        [HttpPut("UpdateGroupTaskStatus")]
        public async Task<IActionResult> UpdateStatus([FromQuery] int id)
        {
            await _groupTaskService.UpdateGroupTaskStatus(id);
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddGroupTaskRequest addGroupTaskRequest)
        {
            await _groupTaskService.CreateGroupTask(addGroupTaskRequest);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            var result = await _groupTaskService.DeleteGroupTask(id);
            if (result)
            {
                return Ok();
            }
            return NotFound();

        }
    } 
}
