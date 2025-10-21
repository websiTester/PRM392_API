using Microsoft.AspNetCore.Mvc;
using PRM392_API.Models;
using PRM392_API.Repositories.Interface;
using PRM392_API.ViewModels;

namespace PRM392_API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class AccountController : Controller
	{

		private readonly IAccountRepository _accountRepository;
		public AccountController(IAccountRepository accountRepository)
		{
			_accountRepository = accountRepository;
		}

		[HttpPost("Login")]
		public async Task<IActionResult> Login([FromBody] LoginViewModel model)
		{
			if(!ModelState.IsValid)
			{
				// Authentication logic here
				return BadRequest("Username and password are required");
			}

			var user = await _accountRepository.Login(model.Username, model.Password);
			if (user != null)
			{
				return Ok(user);
			} else
			{
				return Unauthorized("Invalid username or password");
			}
				
		}



		[HttpPost("Register")]
		public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
		{
			if (!ModelState.IsValid)
			{
				// Authentication logic here
				return BadRequest("Please fill in all the input");
			}

			if(model.Password != model.ConfirmPassword)
			{
				return BadRequest("Password and confirm password do not match");
			}

			var user = new User() { 
				Username = model.Username,
				Password = model.Password,
				RoleId = model.RoleId
			};

			var result = await _accountRepository.Register(user);

			if (result)
			{
				return Ok("Register successfully");
			} else
			{
				return BadRequest("Register failed");
			}

		}


	}
}
