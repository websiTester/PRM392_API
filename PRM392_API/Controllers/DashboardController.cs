using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRM392_API.DTOs.Dashboard;
using PRM392_API.Repositories.Interface;
using PRM392_API.Services.Implementation;
using PRM392_API.Services.Interface;

namespace PRM392_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardService _service;
        public DashboardController (IDashboardService service)
        {
            _service = service;
        }
        [HttpGet("dashboard")]
        public ActionResult<DashboardViewModel> GetDashboard()
        {
            var vm = _service.GetDashboard();
            return Ok(vm);
        }

        // ====== 2. Danh sách người dùng ======
        // GET: api/users
        [HttpGet("user")]
        public ActionResult<List<UListViewModel>> GetUserList()
        {
            var list = _service.GetUserList();
            return Ok(list);
        }

        // ====== 3. Lấy 1 user theo id ======
        // GET: api/users/5
        [HttpGet("user/{id:int}")]
        public ActionResult<UListViewModel> GetUserById(int id)
        {
            var user = _service.GetUserByID(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // ====== 4. Cập nhật trạng thái active ======
        // PUT: api/users/5/status?status=true
        [HttpPut("user/{id:int}/status")]
        public IActionResult UpdateUserStatus(int id, [FromQuery] bool status)
        {
            var result = _service.UpdateUserStatus(id, status);

            if (!result)
            {
                // tuỳ bạn: NotFound hoặc BadRequest,
                // ở đây giả định false = không tìm thấy user
                return NotFound();
            }

            return NoContent();
        }
    }
}
