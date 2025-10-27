using PRM392_API.Models;

namespace PRM392_API.Repositories.Interface
{
	public interface IAccountRepository
	{
		public Task<User> Login(string username, string password);

		public Task<bool> Register(User user);

		public Task<User> GetUser(string username);

		public Task<User> UpdateUser(User user);
	}
}
