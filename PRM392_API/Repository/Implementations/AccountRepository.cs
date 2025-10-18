using PRM392_API.Models;
using PRM392_API.Repository.Interfaces;

namespace PRM392_API.Repository.Implementations
{
	public class AccountRepository : IAccountRepository
	{
		private readonly PRM392Context _context;

		public AccountRepository(PRM392Context context)
		{
			_context = context;
		}
		public bool Login(string username, string password)
		{
			User user = _context.Users.FirstOrDefault(u => u.Username.ToLower() == username.ToLower() 
			&& u.Password == password);

			return user != null;
		}
	}
}
