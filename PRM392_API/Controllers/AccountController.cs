using Microsoft.AspNetCore.Mvc;
using PRM392_API.Models;
using PRM392_API.Repositories.Interface;
using PRM392_API.RequestModel;
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
			int a = 1;
			int b = 2;
			int c = 3;
			int d = 4;
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

			if(await _accountRepository.GetUser(model.Username) != null)
			{
				return BadRequest("Username already exists");
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

		[HttpPut("Update")]
		public async Task<IActionResult> UpdateUser([FromBody] LoginResult model)
		{
			if (!ModelState.IsValid)
			{
				// Authentication logic here
				return BadRequest("Please fill in all the input");
			}

			var user = new User()
			{
				Username = model.Username,
				Email = model.Email,
				FirstName = model.Firstname,
				LastName = model.Lastname,
				Avatar = model.Avatar
			};

			var result = await _accountRepository.UpdateUser(user);

			return Ok(result);


			//if (result)
			//{
			//	return Ok("Update successfully");
			//}
			//else
			//{
			//	return BadRequest("Register failed");
			//}

		}


	}
}
