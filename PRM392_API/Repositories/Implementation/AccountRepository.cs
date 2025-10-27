using Microsoft.EntityFrameworkCore;
using PRM392_API.Models;
using PRM392_API.Repositories.Interface;

namespace PRM392_API.Repositories.Implementation
{
	public class AccountRepository : IAccountRepository
	{
		private readonly PRM392Context _context;

		public AccountRepository(PRM392Context context)
		{
			_context = context;
		}

		public async Task<User> GetUser(string username)
		{
			return await _context.Users.FirstOrDefaultAsync(u => u.Username.ToLower() == username.ToLower());
		}

		public async Task<User> Login(string username, string password)
		{
			User user = await _context.Users.FirstOrDefaultAsync(u => u.Username.ToLower() == username.ToLower()
			&& u.Password == password);

			return user;
			
		}

		public async Task<bool> Register(User user)
		{
			_context.Users.Add(user);
			var result = await _context.SaveChangesAsync();
			return result > 0;
		}

		public async Task<User> UpdateUser(User user)
		{
			User existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Username == user.Username);

			if (existingUser != null)
			{

				existingUser.Email = user.Email;
				existingUser.FirstName = user.FirstName;
				existingUser.LastName = user.LastName;
				existingUser.Avatar = user.Avatar;
				await _context.SaveChangesAsync();
			}
			return existingUser;
		}
	}
}
