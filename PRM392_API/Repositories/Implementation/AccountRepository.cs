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
		public async Task<bool> Login(string username, string password)
		{
			//User user = await _context.Users.FindAsync(u => u.Username.ToLower() == username.ToLower() 
			//&& u.Password == password);

			//return user != null;
			return true;
		}
	}
}
