using Microsoft.AspNetCore.Mvc;
using PRM392_API.Repository.Interfaces;
using PRM392_API.ViewModels;

namespace PRM392_API.Controllers
{
	[ApiController]
	[Route("api/{controller}")]
	public class AccountController : Controller
	{

		private readonly IAccountRepository _accountRepository;
		public AccountController(IAccountRepository accountRepository)
		{
			_accountRepository = accountRepository;
		}

		[HttpPost]
		public async Task<IActionResult> Login([FromBody] LoginViewModel model)
		{
			if(!ModelState.IsValid)
			{
				// Authentication logic here
				return BadRequest("Username and password are required");
			}


			return Ok("Login Success");
		}
	}
}
