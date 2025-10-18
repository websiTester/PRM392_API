namespace PRM392_API.Repositories.Interface
{
	public interface IAccountRepository
	{
		public Task<bool> Login(string username, string password);
	}
}
